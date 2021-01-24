        public class LogEntries
        {
            public List<string> ErrorCodes { get; set; }
        }
    
        public LogEntries GetEntries()
        {
            var logEntries = new LogEntries();
            using (var conn = new SqlConnection("YOUR CONNECTION STRING"))
            {
                conn.Open();
                var errorCodes = conn.Query<string>("YOUR SQL", commandType: CommandType.Text);
                logEntries.ErrorCodes = errorCodes.ToList();
            }
            
            return logEntries;
        }
