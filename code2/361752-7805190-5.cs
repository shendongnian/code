    public class Person
    {
        public Person(out int seed)
        {
            seed = RuntimeHelpers.GetHashCode(this);
        }
    }
