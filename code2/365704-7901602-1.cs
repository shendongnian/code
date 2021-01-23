    public class MyClass
    {
        public static MyClass Load(XDocument xDoc)
        {
            XmlSerializer _s = new XmlSerializer(typeof(MyClass));
            return (MyClass)_s.Deserialize(xDoc.CreateReader());
        }
    }
