    public class Test { }
    
    public class Elems
    {
        public Elems()
        {
            How = new List<Test>();
            How.Add(new Test());
            How.Add(new Test());
            How.Add(new Test());
        }
        [XmlArray("how")]
        [XmlArrayItem("testing")]
        public List<Test> How { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var elems = new Elems();
            var serializer = new XmlSerializer(elems.GetType());
            serializer.Serialize(Console.Out, elems);
        }
    }
