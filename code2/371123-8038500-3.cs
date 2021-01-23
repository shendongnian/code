    public class xxx
    {
        private int myValue;
        [XmlElement("MyProperty")]
        public int MyPropertyForSerialization
        {
            get { return this.myValue; }
            set
            {
                Console.WriteLine("DESERIALIZED");
                this.myValue = value;
            }
        }
        [XmlIgnore]
        public int MyProperty
        {
            get { return this.myValue; }
            set
            {
                Console.WriteLine("NORMAL");
                this.myValue = value;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            xxx instance = new xxx();
            instance.MyProperty = 100; // This should print "NORMAL"
            // We serialize
            var serializer = new XmlSerializer(typeof(xxx));
            var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, instance);
            // Let's print our XML so we understand what's going on.
            memoryStream.Position = 0;
            var reader = new StreamReader(memoryStream);
            Console.WriteLine(reader.ReadToEnd());
            // Now we deserialize
            memoryStream.Position = 0;
            var deserialized = serializer.Deserialize(memoryStream) as xxx; // This should print DESERIALIZED
            Console.ReadLine();
        }
    }
