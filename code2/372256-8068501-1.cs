    public class MyClass
    {
        private readonly IEnumerable<int> ints;
    
        public MyClass(IEnumerable<int> ints)
        {
            this.ints = ints;
        }
    
        public IEnumerable<int> IntsGreaterThan5()
        {
            return this.ints.Where(x => x > 5);
        }
        public int? MaxInt()
        {
            return this.ints.Max(x => new int?(x));
        }
    }
