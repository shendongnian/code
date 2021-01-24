    class EventLogItem
    {
        public string Date { get; set; }
        public string Category { get; set; }
        public string Event { get; set; }
        public string FullLine => $"{Date} {Category} {Event}";
    }
