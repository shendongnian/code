    ProcessStartInfo processInfo = new ProcessStartInfo("Write500Lines.exe");
    processInfo.ErrorDialog = false;
    processInfo.UseShellExecute = false;
    processInfo.RedirectStandardOutput = true;
    processInfo.RedirectStandardError = true;
    Process proc = Process.Start(processInfo);
    // You can pass any delegate that matches the appropriate 
    // signature to ErrorDataReceived and OutputDataReceived
    proc.ErrorDataReceived += (sender, errorLine) => { if (errorLine.Data != null) Trace.WriteLine(errorLine.Data); };
    proc.OutputDataReceived += (sender, outputLine) => { if (outputLine.Data != null) Trace.WriteLine(outputLine.Data); };
    proc.BeginErrorReadLine();
    proc.BeginOutputReadLine();
    proc.WaitForExit();
