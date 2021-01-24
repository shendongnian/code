    public struct Example
    {
        public int Number { get; set; }
    
        public Example(int number) : this()
        {
            Number = number;
        }
        public Example()
        {
            Console.WriteLine("Hello");
        }
    }
