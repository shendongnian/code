    private void executeCommand(string programFilePath, string commandLineArgs, string workingDirectory)
		{
			Process myProcess = new Process();
			myProcess.StartInfo.WorkingDirectory = workingDirectory;
			myProcess.StartInfo.FileName = programFilePath;
			myProcess.StartInfo.Arguments = commandLineArgs;
			myProcess.StartInfo.UseShellExecute = false;
			myProcess.StartInfo.CreateNoWindow = true;
			myProcess.StartInfo.RedirectStandardOutput = true;
			myProcess.StartInfo.RedirectStandardError = true;
			myProcess.Start();
			StreamReader sOut = myProcess.StandardOutput;
			StreamReader sErr = myProcess.StandardError;
			try
			{
				string str;
				// reading errors and output async...
				while ((str = sOut.ReadLine()) != null && !sOut.EndOfStream)
				{	
				  logMessage(str + Environment.NewLine, true);
				  Application.DoEvents();
				  sOut.BaseStream.Flush();
				}
				
				while ((str = sErr.ReadLine()) != null && !sErr.EndOfStream)
				{
				  logError(str + Environment.NewLine, true);
				  Application.DoEvents();
				  sErr.BaseStream.Flush();
				}
				myProcess.WaitForExit();
			}
			finally
			{
				sOut.Close();
				sErr.Close();
			}
		}
