    public sealed class Something 
    {
        public static Something A1 = new Something("A", 1);
        public static Something A2 = ...;
        private Something(string letter, int number)
        {
            Letter = letter;
            Number = number;
        }
        public string Letter { get; private set; }
        public int Number { get; private set; }
    }
