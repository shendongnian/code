    Process p = new Process();
    p.StartInfo.FileName = pathToApp;
    p.EnableRaisingEvents = true;
    p.Exited += OnCalibrationProcessExited;  // hooks up your handler to the Process
    p.Start();
    
    // Now .NET will call this method when the process exits
    private void OnCalibrationProcessExited(object sender, EventArgs e)
    {
      // set Topmost
    }
