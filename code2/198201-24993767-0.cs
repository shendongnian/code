		var wh = new AutoResetEvent(false);
		var fsw = new FileSystemWatcher(".");
		fsw.Filter = "log-file-to-read";
		fsw.Changed += (s,e) => wh.Set();
		
		var fs = new FileStream("aaa", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		using (var sr = new StreamReader(fs))
		{
			var s = "";
			while (true)
			{
				s = sr.ReadLine();
				if (s != null)
					Console.WriteLine(s);
				else
					wh.WaitOne(1000);
			}
		}
		
		wh.Close();
