    struct NumberSet
    {
        public NumberSet(int number)
        {
            Number = number;
            Sum = number; // Always begin with the first number added.
        }
            
        public int Number { get; } // Cannot be changed later.
        public int Sum { get; private set; }
        public void Increment() => Sum += Number; // Don't need a parameter. The Number is known.
        public override string ToString() => $"Number = {Number}, Sum = {Sum}";
    }
