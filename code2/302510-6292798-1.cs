    public class Person : MarshalByRefObject
    {
        internal Person(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public string AppDomainName { get { return AppDomain.CurrentDomain.FriendlyName; } }
    }
    public class PersonFactory
    {
        public static Person CreatePerson(string name)
        {
            return new Person(name);
        }
        public static Person CreatePersonInAppDomain(string name, AppDomain domain)
        {
            return (Person)domain.CreateInstanceAndUnwrap(
                typeof(Person).Assembly.FullName, 
                typeof(Person).FullName, 
                false, 
                BindingFlags.NonPublic | BindingFlags.Instance, 
                null, 
                new object[] { name }, 
                null, 
                null
                );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {            
            AppDomain domain = AppDomain.CreateDomain("NewDomain");
            Person person1 = PersonFactory.CreatePerson("John Smith");
            Person person2 = PersonFactory.CreatePersonInAppDomain("Jane Smith", domain);
            Console.WriteLine("Person: Name={0}, Domain={1}", person1.Name, person1.AppDomainName);
            Console.WriteLine("Person: Name={0}, Domain={1}", person2.Name, person2.AppDomainName);
        }
    }
