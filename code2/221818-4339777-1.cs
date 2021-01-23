    class Program
    {
        static void Main(string[] args)
        {
            var ws = new[] { new TestClass { Name = true } };
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, ws);
                stream.Seek(0, SeekOrigin.Begin);
                ws = (TestClass[])formatter.Deserialize(stream);
            }
            Console.ReadLine();
        }
    }
    [Serializable]
    public class TestClass : ISerializable
    {
        public TestClass()
        { }
        protected TestClass(SerializationInfo info, StreamingContext context)
        {
            this.Name = info.GetString("name");
        }
        public string Name { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", this.Name);
        }
    }
So I think, that you've messed something up with GetValue() and AddValue()
