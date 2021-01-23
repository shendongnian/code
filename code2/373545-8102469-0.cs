    class Puzzle
    {
        private string Value { get; set; }
    
        public Puzzle()
        {
            Value = String.Empty;
        }
        public void Add(String item)
        {
            Value += "," + item;
        }
    
        public override string ToString()
        {
            return Value;
        }
    }
