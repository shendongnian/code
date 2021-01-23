            string projectFileName = "C:\\Users...\\MySolution.sln";//<--- change here can be another VS type ex: .vcxproj
            BasicLogger Logger = new BasicLogger();
            var projectCollection = new ProjectCollection();
            var buildParamters = new BuildParameters(projectCollection);
            buildParamters.Loggers = new List<Microsoft.Build.Framework.ILogger>() { Logger };
            var globalProperty = new Dictionary<String, String>();
            globalProperty.Add("Configuration", "Debug"); //<--- change here 
            globalProperty.Add("Platform", "x64");//<--- change here 
            BuildManager.DefaultBuildManager.ResetCaches();
            var buildRequest = new BuildRequestData(projectFileName, globalProperty, null, new String[] {  "Build" }, null);
            var buildResult = BuildManager.DefaultBuildManager.Build(buildParamters, buildRequest);
            if (buildResult.OverallResult == BuildResultCode.Failure)
            {
                // catch result ..
            }          
            MessageBox.Show(Logger.GetLogString());    //display output ..
