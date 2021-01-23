    public class FibonacciNumber
    {
        private readonly int first;
        private readonly int second;
    
        public FibonacciNumber()
        {
            this.first = 0;
            this.second = 1;
        }
    
        private FibonacciNumber(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
    
        public int Number
        {
            get { return first + second; }
        }
    
        public FibonacciNumber Next
        {
            get
            {
                return new FibonacciNumber(this.second, this.Number);
            }
        }
    
        public bool IsMultipleOf2
        {
            get { return (this.Number % 2 == 0); }
        }
    }
