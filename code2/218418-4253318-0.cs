		//System.Collections.Generic.IEnumerable<String> lines = File.ReadLines("C:\\Test\\ntfs2.txt");
		String value = "Thu Mar 02 1995 21:31:00,2245107,m...,r/rrwxrwxrwx,0,0,8349-128-3,C:/Program Files/AccessData/AccessData Forensic Toolkit/Program/wordnet/Adj.dat";
		String[] token = value.Split(',');
		String[] datetime = token[0].Split(' ');
		String timeText = datetime[4]; // The String array contans 21:31:00
		DateTime time = Convert.ToDateTime(timeText); // Converts only the time
		Console.WriteLine(time.ToString("HH:mm:ss"));
