    public class Person
    {
        protected Person()
        {
        }
        public static Person BuildPerson(out int seed)
        {
            var person = new Person();
            seed = RuntimeHelpers.GetHashCode(person);
            return person;
        }
    }
