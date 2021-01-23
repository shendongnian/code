				ProcessStartInfo startInfo
					= new ProcessStartInfo(File, mysqldumpCommand);
				process.StartInfo.FileName = File;
				process.StartInfo.Arguments = mysqldumpCommand;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.RedirectStandardInput = false;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
				process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
				process.EnableRaisingEvents = true;
				ConcurrentQueue<string> messages = new ConcurrentQueue<string>();
				process.ErrorDataReceived += (object se, DataReceivedEventArgs ar) =>
				{
					string data = ar.Data;
					if (!string.IsNullOrWhiteSpace(data))
						messages.Enqueue(data);
				};
				process.OutputDataReceived += (object se, DataReceivedEventArgs ar) =>
				{
					string data = ar.Data;
					if (!string.IsNullOrWhiteSpace(data))
						messages.Enqueue(data);
				};
				process.Start();
				process.BeginErrorReadLine();
				process.BeginOutputReadLine();
				while (!process.HasExited)
				{
					string data = null;
					if (messages.TryDequeue(out data))
						UpdateOutputText(data, tbOutput);
					Thread.Sleep(5);
				}
				
				process.WaitForExit();
