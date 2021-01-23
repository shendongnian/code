    public class Person
    {
        internal Person(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
    public class PersonFactory
    {
        public static Person CreatePerson(string name)
        {
            return new Person(name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = PersonFactory.CreatePerson("John Smith");
        }
    }
