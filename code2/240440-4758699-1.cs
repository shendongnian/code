    class LogEntry
    {
        public string CaseNumber { get; set; }
        public string User { get; set; }
        public string Software{ get; set; }
        public string DateStarted { get; set; }
        public string DateEnded { get; set; }
    }
    List<LogEntry> items = new List<LogEntry>();
    
    var line = reader.ReadLine();
    while (line != null)
    {
        int pos = line.IndexOf(':');
        var name = line.Substring(0, pos).Replace(" ", string.Empty);
        var value = line.Substring(pos+1);
        var entry = new LogEntry();
        var pi = entry.GetType().GetProperty(name);
        pi.SetValue(entry, value, null);
        items.Add(entry);
     
        line = reader.ReadLine();
    }
