	// Kludge to get USB Drive to be recognized again
	void UsbCleanup() {
		var proc1 = new System.Diagnostics.Process();
		proc1.StartInfo.FileName               = @"C:\\Windows\\System32\\mountvol.exe";
		proc1.StartInfo.Arguments              = @"/R";
		proc1.StartInfo.CreateNoWindow         = true;
		proc1.StartInfo.UseShellExecute        = false;
		proc1.StartInfo.RedirectStandardOutput = true;
		proc1.StartInfo.RedirectStandardError  = true;
		proc1.Start();			
		proc1.WaitForExit();
		string proc1out = proc1.StandardOutput.ReadToEnd();
		string proc1err = proc1.StandardError.ReadToEnd();			
		if (proc1.ExitCode != 0) {
			string msg = proc1out + "\r\n\r\n" + proc1err;
			MessageBox.Show(msg, "Error: Mountvol /R");
		}
		proc1.Close();
		var proc2 = new System.Diagnostics.Process();
		proc2.StartInfo.FileName               = @"C:\\Windows\\System32\\mountvol.exe";
		proc2.StartInfo.Arguments              = @"/E";
		proc2.StartInfo.CreateNoWindow         = true;
		proc2.StartInfo.UseShellExecute        = false;
		proc2.StartInfo.RedirectStandardOutput = true;
		proc2.StartInfo.RedirectStandardError  = true;
		proc2.Start();			
		proc2.WaitForExit();
		string proc2out = proc2.StandardOutput.ReadToEnd();
		string proc2err = proc2.StandardError.ReadToEnd();			
		if (proc2.ExitCode != 0) {
			string msg = proc2out + "\r\n\r\n" + proc2err;
			MessageBox.Show(msg, "Error: Mountvol /E");
		}
		proc2.Close();
		return;
	}
	
	bool IsAdministrator() 
	{
		var id   = System.Security.Principal.WindowsIdentity.GetCurrent();
		var prin = new System.Security.Principal.WindowsPrincipal(id);
		return prin.IsInRole(
			System.Security.Principal.WindowsBuiltInRole.Administrator);
	}
