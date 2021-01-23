    public static class Logger
	{
		public static StringBuilder LogString = new StringBuilder();
		public static void WriteLine(string str)
		{
			Console.WriteLine(str);
			LogString.Append(str).Append(Environment.NewLine);
		}
		public static void Write(string str)
		{
			Console.Write(str);
			LogString.Append(str);
		}
		public static void SaveLog(bool Append = false, string Path = "./Log.txt")
		{
			if (LogString != null && LogString.Length > 0)
			{
				if (Append)
				{
					using (StreamWriter file = System.IO.File.AppendText(Path))
					{
						file.Write(LogString.ToString());
						file.Close();
						file.Dispose();
					}
				}
				else
				{
					using (System.IO.StreamWriter file = new System.IO.StreamWriter(Path))
					{
						file.Write(LogString.ToString());
						file.Close();
						file.Dispose();
					}
				}				
			}
		}
	}
