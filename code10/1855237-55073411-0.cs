    void Main()
    {
        var summary = BenchmarkRunner.Run<CollectionBenchmark>();
    }
    
    [MemoryDiagnoser]
    public class CollectionBenchmark
    {
        private static Random random = new Random();
        private List<MyObject> _list = new List<MyObject>();
    
        [GlobalSetup]
        public void GlobalSetup()
        {
            var rnd = new Random();
    
            for (var i = 0; i < 1000; i++)
            {
                _list.Add(new MyObject { Category = rnd.Next(1, 4), IsActive = rnd.Next(0, 2) != 0 });
            }
        }
    
        [Benchmark]
        public void OptionOne()
        {
            var one = _list.Where(l => l.IsActive)
                .GroupBy(l => l.Category)
                .Select(g => g.Count() > 300)
                .Any();
        }
    
        [Benchmark]
        public void OptionTwo()
        {
            var two = _list.Where(l => l.IsActive)
                .GroupBy(l => l.Category)
                .Select(g => g.Count())
                .Any(c => c > 300);
        }
    }
    
    public class MyObject
    {
        public bool IsActive { get; set; }
        public int Category { get; set; }
    }
