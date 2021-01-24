    public class Letter
    {
        public int Value { get; set; }
        public char Text { get; set; }
        public override string ToString()
        {
            return $"{Text} ({Value})";
        }
    }
