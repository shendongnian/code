    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Serialized));
            Serialized s = new Serialized();
            serializer.Serialize(Console.Out, s);
            Serialized s2 = new Serialized { Value = 10 };
            serializer.Serialize(Console.Out, s2);
            Console.ReadLine();
        }
    }
    public class Serialized
    {
        [XmlAttribute]
        [DefaultValue(0)]
        public int Value { get; set; }
    }
