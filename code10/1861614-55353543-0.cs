    Process gitProcess = new Process();
    gitInfo.Arguments = YOUR_GIT_COMMAND; // such as "fetch origin"
    gitInfo.WorkingDirectory = YOUR_GIT_REPOSITORY_PATH;
    gitInfo.UseShellExecute = false; 
    gitProcess.StartInfo = gitInfo;
    gitProcess.Start();
    string stderr_str = gitProcess.StandardError.ReadToEnd();  // pick up STDERR
    string stdout_str = gitProcess.StandardOutput.ReadToEnd(); // pick up STDOUT
    gitProcess.WaitForExit();
    gitProcess.Close();
