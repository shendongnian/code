    /// <summary>
	/// Execute the command and output the result
	/// </summary>
	private String Command(string command)
	{
		int time_out = 6;
		System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
		
		psi.FileName = @"C:\ffmpeg\bin\ffmpeg.exe";
		psi.RedirectStandardInput = false;
		psi.RedirectStandardOutput = true;
		psi.UseShellExecute = false;
		//Do not display windows
		psi.CreateNoWindow = true;
		//Specify command line
		psi.Arguments = command;
		//Start-up
		Process p = Process.Start(psi);
		//Read output
		string results = p.StandardOutput.ReadToEnd();
		//WaitForExit needs to be after ReadToEnd
		//(To prevent blocking by parent process and child process)
		p.WaitForExit(time_out * 1000);  //Wait maximum specified milliseconds until process terminates
		if (!p.HasExited) p.Close();
		//Display output result
		return results;
	}
