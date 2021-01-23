	public void CaptureProcess(String Command, String Arguments, String Filename)
	{
		// This is the code for the base process
		Process myProcess = new Process();
		myProcess.StartInfo = new ProcessStartInfo(Command, Arguments);
		myProcess.StartInfo.UseShellExecute = false;
		myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		myProcess.StartInfo.RedirectStandardOutput = true;
		// Open a filestream for the output
		using (FileStream fs = new FileStream(Filename, FileMode.OpenOrCreate))
		{
			using (StreamWriter sw = new StreamWriter(fs))
			{
			
				// open the stream and capture all output from the process until it dies.
				using (StreamReader ProcessOutput = myProcess.StandardOutput)
				{
					myProcess.Start();
					string output = ProcessOutput.ReadToEnd();
					sw.Write(output);
					myProcess.WaitForExit();
					myProcess.Close();
				}
			}
		}
	}
