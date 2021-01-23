    	public void eventG(object sender, FileSystemEventArgs e)
		{
			Thread eventThread = new Thread(ThreadProcEventG);
			eventThread.Start(e);
		}
		private void ThreadProcEventG(object eventArgs)
		{
			var e = (FileSystemEventArgs)eventArgs;
			string CurrentPrinter = "";
			string findPrt = e.FullPath.Substring(0, e.FullPath.Length-(e.Name.Length + 1));
			string findPrtExt = e.Name.Substring(e.Name.LastIndexOf("."));
			for (int i = 1; i <= Properties.Settings.Default.NumberOfPrinters; i++)
			{
				string testPrt = Properties.Settings.Default["Printer" + i + "Read"].ToString();
				string testExt = Properties.Settings.Default["Printer" + i + "ExtIn"].ToString();
				if (testPrt == findPrt && testExt == findPrtExt)
				{
					CurrentPrinter = "Printer" + i.ToString();
					POSPrinter printer = new POSPrinter(Properties.Settings.Default["Printer" + i + "Port"].ToString(), (int)Properties.Settings.Default["Printer" + i + "Speed"]);
					addToBoxWaiting(e.FullPath.ToString());
					string file = e.FullPath;
					printer.BeginPrint();
					printer.PrintFile(file);
					printer.EndPrint();
					printer.Dispose();
					if ((bool)Properties.Settings.Default[CurrentPrinter + "Delete"])
					{
						IsFileLocked(file);
						System.IO.File.Delete(file);
					}
					else
					{
						System.IO.File.Move(file, Properties.Settings.Default[CurrentPrinter + "Store"] + "\\" + e.Name + Properties.Settings.Default[CurrentPrinter + "ExtOut"]);
					}
					removeFromBoxWaiting(e.FullPath.ToString());
					addToBoxFinished(e.FullPath.ToString());
					busy = false;
					break;
				}
			}
		}
