    // create the npm process
	npmProcess = new Process
	{
		StartInfo =
		{
			FileName = "cmd.exe",
			UseShellExecute = false,
			CreateNoWindow = true, // this is probably optional
			ErrorDialog = false, // this is probably optional
			RedirectStandardOutput = true,
			RedirectStandardInput = true
		}
	};
    
    // register for the output (for reading the output)
    npmProcess.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
	{
		string output = e.Data;
		// inspect the output text here ...
	};
    
    // start the npm process
    npmProcess.Start();
    npmProcess.BeginOutputReadLine();
    
    // execute your command
    npmProcess.StandardInput.WriteLine("npm quicktype --version");
