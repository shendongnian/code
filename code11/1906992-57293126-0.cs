    Task("UploadArtifacts")
     .IsDependentOn("ZipArtifacts")
     .WithCriteria(BuildSystem.IsRunningOnAzurePipelinesHosted)
     .Does(() => {
      TFBuild.Commands.UploadArtifact("website", zipFileName, "website"); 
      TFBuild.Commands.UploadArtifact("website", deployCakeFileName, "website"); 
    });
