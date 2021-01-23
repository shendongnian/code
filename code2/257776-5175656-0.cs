    class DebugError
    {
        public int Number { get; private set; }
        public string Description { get; private set; }
        public string Line { get; private set; }
        public string Column { get; private set; }
        public DebugError(int number, string description, string line, string column)
        {
            Number = number;
            Description = description;
            Line = line;
            Column = column;
        }
    }
