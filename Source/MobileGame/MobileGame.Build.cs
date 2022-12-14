// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class MobileGame : ModuleRules
{
	public MobileGame(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "HeadMountedDisplay" });
		
		if(Target.Platform==UnrealTargetPlatform.Android)
        {
        	PublicAdditionalLibraries.AddRange(new string[] { System.IO.Path.Combine(ModuleDirectory, "ThirdParty","pugi","pugixml.lib","aa") });
        	//PublicAdditionalLibraries.AddRange(new string[] { System.IO.Path.Combine(ModuleDirectory, "ThirdParty","sol2","lua-5.4.4.lib","aa") });
        }
        else
        {
	        if (Target.Platform == UnrealTargetPlatform.IOS)
	        {
		        PublicAdditionalLibraries.AddRange(new string[]{System.IO.Path.Combine(ModuleDirectory, "ThirdParty","pugi","pugixml.a")});
		       // PublicAdditionalLibraries.AddRange(new string[]{System.IO.Path.Combine(ModuleDirectory, "ThirdParty","sol2","lua-5.4.4.a")});
	        }
        }
		if (Target.Platform == UnrealTargetPlatform.Android)
		{
			PrivateDependencyModuleNames.AddRange(new string[] { "Launch", "ApplicationCore"});
			PrivateIncludePaths.AddRange(new string[] { "/Source/Runtime/Launch/Private"});
			string pluginPath = Utils.MakePathRelativeTo(ModuleDirectory, Target.RelativeEnginePath);
			AdditionalPropertiesForReceipt.Add("MobileGame",System.IO.Path.Combine(pluginPath,"PhotoLibrary_APL.xml"));
		}
	}
}
