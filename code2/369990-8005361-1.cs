    public class SomeClass
    {
        public void Something()
        {
            List<int> values = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> valuesParam = values;
            valuesParam = values.Where(i => i < 3);
            // Will print 1 through 5, not 1 through 2...
            foreach(int value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
