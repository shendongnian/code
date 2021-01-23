    public class Person
    {
        private static int seed;
        public Person(out int seed)
        {
            seed = Interlocked.Increment(ref Person.seed);
        }
    }
