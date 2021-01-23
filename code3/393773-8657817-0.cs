        namespace Indexer
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Persons MyPeople = new Persons();
                    Console.WriteLine("MyPeople[0] " + MyPeople[0].Name);
                    Console.WriteLine("MyPeople[0] " + MyPeople[1].Name);
                    Console.WriteLine("MyPeople[Jim] " + MyPeople["Jim"].Name);
                    Console.ReadLine();
                }
            }
            public class Persons
            {
                private List<Person> persons = new List<Person>();
                public int Count { get { return persons.Count; } }
                public Person this[int index]
                {
                    get
                    {
                        return persons[index];
                    }
                    set
                    {
                        persons[index] = value;
                    }
                }
                public Person this[string name]
                {
                    get
                    {
                        foreach (Person p in persons)
                        {
                            if (p.Name == name) return p;
                        }
                        return null;
                    }
                }
                public Persons()
                { 
                    persons.Add(new Person("Jim"));
                    persons.Add(new Person("Harry"));
                }
                public class Person
                {
                    private string name;
                    public string Name { get { return name; } }
                    public Person(string Name) { name = Name; }
                }
            }
        }
