		public IEnumerable<LogEntry> GetLogEntries(string eventType, DateTime logDate)
		{
			var results = from g in this.context.LogEntry
						  where g.PartitionKey == String.Format("{0}_{1}", eventType, logDate.ToString("yyyyMMdd"))
						  select g;
			return results;
		}
