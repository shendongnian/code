	class Log {
		Dictionary<DateTime, List<LogEntry>} Entries { get; private set; }
		
		public void PrintLogs()
		{
			foreach (var date in Entries.Keys)
			{
				Console.WriteLine(date);
				
				foreach (var entry in Entries[date])
				{
					entry.PrintEntry();
				}
			}
		}
	}
	class LogEntry {
		public List<string> EntryLines { get; set; }
		public DateTime Date { get; set; }
		
		public void PrintEntry()
		{
			foreach (var line in EntryLines)
				Console.WriteLine(line);
			}
	}
