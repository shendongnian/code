    class AccumulateToString
    {
        private int sum;
        public string ToString(int val)
        { this.sum += val; return this.sum.ToString(); }
    }
    var fn = new Converter<int, string>(new AccumulateToString().ToString);
    Console.WriteLine(fn(2)); // <-- called like a function but is an object w/ state
