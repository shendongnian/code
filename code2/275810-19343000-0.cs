    public class LazyListTest
    {
        private int _count = 0;
        public void Test()
        {
            var numbers = Enumerable.Range(1, 40);
            var numbersQuery = numbers.Select(GetElement).ToLazyList(); // Cache lazy
            var total = numbersQuery.Take(3)
                .Concat(numbersQuery.Take(10))
                .Concat(numbersQuery.Take(3))
                .Sum();
            Console.WriteLine(_count);
        }
        private int GetElement(int value)
        {
            _count++;
            // Some slow stuff here...
            return value * 100;
        }
    }
