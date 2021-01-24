    class Notes
    {
        public string Note { get; set; }
        public DateTime TimeStamp { get; set; }
        public Notes(string note)
        {
            Note = note;
            TimeStamp = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Note}-{TimeStamp.ToString()}";
        }
    }
