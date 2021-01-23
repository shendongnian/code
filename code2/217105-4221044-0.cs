    class Program
    {
        static void Main(string[] args)
        {   
            const string infile = "x:\\Persons.xml";
            Persons p;
            using (var sr = new StreamReader(infile))
            {
                var xs = new XmlSerializer(p.GetType());
                p = (Persons)(xs.Deserialize(sr));
            }
            Console.WriteLine("Deserialized array p from output file " + infile + ".");
            // Print array.
            foreach (var x in p)
                Console.WriteLine(x);
            Console.ReadLine();
        }
    }
    [XmlType(TypeName = "Persons")]
    public class Persons : IEnumerable<Person>
    {
        private List<Person> inner = new List<Person>();
        public void Add(object o)
        {
            inner.Add((Person)o);
        }
        public IEnumerator<Person> GetEnumerator()
        {
            return inner.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Person
    {
        [XmlAttribute]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
