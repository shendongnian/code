    class Program
    {
        static void Main(string[] args)
        {
            var o = new ContainerClass();
            o.Values = new List<SomeClass> {new SomeClass<int>(), new SomeClass<long>()};
    
            var xml = Atlas.Xml.Serializer.Serialize(o, true);
        }
    }
    public class ContainerClass
    {
        public List<SomeClass> Values { get; set; }
    }
    
    public class SomeClass
    {
    }
    public class SomeClass<T> : SomeClass
    {
    }
