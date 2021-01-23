    public class Foo { }
    
    class Program
    {
        static void Main()
        {
            var foo = new Foo();
            var serializer = new XmlSerializer(foo.GetType());
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            serializer.Serialize(Console.Out, foo, ns);
        }
    }
