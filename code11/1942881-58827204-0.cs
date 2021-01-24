        public class LogEntries
        {
           public string ErrorCode { get; set; }
        }
    
        public List<LogEntries> GetEntries()
        {
            IEnumerable<LogEntries> entries;
            using (var conn = new SqlConnection("YOUR CONNECTION STRING"))
            {
                conn.Open();
                entries = conn.Query<LogEntries>("YOUR SQL", commandType: CommandType.Text);
            }
    
            return entries.ToList();
        }
