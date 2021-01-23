    class Blah
    {
        // Supply factory method to generate the numbers, but actual generation will be deferred
        private static Lazy<List<int>> MyMagicNumbers = new Lazy<List<int>>(Blah.GenerateMagicNumbers);
        public void DoSomethingWithMagicNumbers()
        {
            // Call to Lazy<T>.Value will synchronize any calling threads until value is initially generated from the factory
            List<int> magicNumbers = Blah.MyMagicNumbers.Value;
            // ... do something here ...
        }
        private List<int> GenerateMagicNumbers()
        {
            return Enumerable.Range(1, 10000)
                              .AsParallel()
                              .Select(n => n * 3)
                              .ToList();
        }
    }
