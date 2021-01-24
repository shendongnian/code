    class MyClass : IComparable
    {
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public int Number { get; set; }
        // Constructor
        public MyClass()
        {
        }
        public int CompareTo(object obj)
        {
            if (obj is DateTime otherTimestamp)
            {
                return this.Timestamp.CompareTo(otherTimestamp);
            }
            return 0;  // If obj  is not a DateTime or is null, return 0
        }
    }
