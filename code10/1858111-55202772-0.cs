			void getallprocesses(string path)
			{
				Process[] processlist = Process.GetProcesses();
				foreach (Process process in processlist)
				{
					try
					{
						if (string.Compare(process.MainModule.FileName, path, StringComparison.OrdinalIgnoreCase) == 0)
						{
							//hit
						}
					}
					catch
					{
						
					}
				}
			}
