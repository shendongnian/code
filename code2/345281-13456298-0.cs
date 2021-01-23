				var process = new Process
				{
				    StartInfo = new ProcessStartInfo
				    {
				        FileName = "myLegacyConsoleApp.exe",
				        UseShellExecute = false,
				        RedirectStandardOutput = true,
				        WorkingDirectory = @"C:\Program Files\myAppDirectory\",
				    }
				};
				  
				  
				process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
				process.Start();
				
				process.BeginOutputReadLine();
				// You need to wait a bit.. Im sorry..
				System.Threading.Thread.Sleep(5000);
				process.StandardInput.WriteLine("Welcome to Ûberland");
				
				process.WaitForExit();
