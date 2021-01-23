    public class Person
    {
        protected Person()
        {
        }
        public Person BuildPerson(out int seed)
        {
            seed = new Random().Next();
            return new Person();
        }
    }
