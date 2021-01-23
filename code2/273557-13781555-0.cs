    class Program
    {
        static void Main(string[] args)
        {
            TestClass.Create(1).Save(); // Works
            TestClass.Create("asdfqwer").Save(); // Works
            TestClass.Create(DateTime.UtcNow).Save(); // Works
            TestClass.Create(MyEnum.One).Save(); // Fails
        }
    }
    public class TestClass
    {
        public static TestClass<T> Create<T>(T value)
        {
            return new TestClass<T>(value);
        }
    }
    [DataContract]
    public class TestClass<T>
    {
        [DataMember]
        public T _TestVariable;
        public TestClass(T value)
        {
            _TestVariable = value;
        }
        public void Save()
        {
            using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(new MemoryStream()))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(TestClass<T>));
                ser.WriteObject(writer, this);
            }
        }
    }
    public enum MyEnum
    {
        One,
        Two,
        Three
    }
