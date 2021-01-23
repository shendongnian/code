namespace ConsoleApplication1
{
    public class MyClass
    {
        public string SomeProperty
        {
            get;
            set;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
            TextWriter writer = new StreamWriter(@"c:\temp\class.xml");
            MyClass firstInstance = new MyClass();
            firstInstance.SomeProperty = "foo"; // etc
            serializer.Serialize(writer, firstInstance);
            writer.Close();
            FileStream reader = new FileStream(@"c:\temp\class.xml", FileMode.Open);
            MyClass secondInstance = (MyClass)serializer.Deserialize(reader);
            reader.Close();
        }
    }
}
