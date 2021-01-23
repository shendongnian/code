    Process p = new Process();
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.FileName = SCHTASKS;
    p.StartInfo.RedirectStandardError = true;
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.CreateNoWindow = true;
    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    p.StartInfo.Arguments = String.Format("/Query /S {0} /TN {1} /FO TABLE /NH", MachineName, ScheduledTaskName);
    p.Start();
    // Read the error stream
    string error = p.StandardError.ReadToEnd();
    //Read the output string
    p.StandardOutput.ReadLine();
    string tbl = p.StandardOutput.ReadToEnd();
    //Then wait for it to finish
    p.WaitForExit();
    //Check for an error
    if (!String.IsNullOrWhiteSpace(error))
    {
        throw new Exception(error);
    }
    //Parse output
    return tbl.Split(new String[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim().EndsWith("Running");
