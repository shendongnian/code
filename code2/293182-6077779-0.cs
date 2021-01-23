    public static class XmlElementFactory
    {
        public static XmlElement Create(string value)
        {
            var doc = new XmlDocument();
            doc.LoadXml(value);
            return doc.DocumentElement;
        }
    }
    public class Foo
    {
        private readonly XmlElement _xml;
        public Foo(XmlElement xml)
        {
            _xml = xml;
        }
        public override string ToString()
        {
            return _xml.OuterXml;
        }
    }
    class Program
    {
        static void Main()
        {
            var foo = (Foo)ContextRegistry.GetContext().GetObject("foo");
            Console.WriteLine(foo);
        }
    }
