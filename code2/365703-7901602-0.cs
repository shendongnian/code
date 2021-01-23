    public class MyClass
    {
        public static MyClass Load(XDocument xDoc)
        {
            return (MyClass)_s.Deserialize(xDoc.CreateReader());
        }
    }
