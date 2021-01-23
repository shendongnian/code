    public abstract static class Calculation
    {
        public static int Constant { get; set; }
    
        public static int Calculate(int inputValue)
        {
            return inputValue * Constant;
        }
    }
    // ...
    Calculation.Constant = 6;
    Calculation.Calculate(123);
