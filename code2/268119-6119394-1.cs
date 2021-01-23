    Process gitProcess = new Process();
    gitInfo.Arguments = YOUR_GIT_COMMAND; // such as "fetch orign"
    gitInfo.WorkingDirectory = YOUR_GIT_REPOSITORY_PATH;
    gitProcess.StartInfo = gitInfo;
    gitProcess.Start();
    string stderr_str = gitProcess.StandardError.ReadToEnd();  // pick up STDERR
    string stdout_str = gitProcess.StandardOutput.ReadToEnd(); // pick up STDOUT
    gitProcess.WaitForExit();
    gitProcess.Close();
