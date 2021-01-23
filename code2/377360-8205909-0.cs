    public class LogEntry : TableServiceEntity
	{
		public LogEntry(string logType)
		{
			if (LogType == null || LogType.Length == 0)
			{
				if (logType.Length > 0)
					LogType = logType;
				else
					LogType = "Default";
			}
			PartitionKey = string.Format("{0}_{1}", LogType, DateTime.UtcNow.ToString("yyyyMMdd"));
			RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
		}
		public LogEntry()
		{
		}
		public string Message { get; set; }
		public DateTime LogDateTime { get; set; }
		public string LogType { get; set; }
		
	}
