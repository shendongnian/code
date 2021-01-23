    public class MyClass
    {
        public MyClass() {}
        public MyClass(XElement data)
        {
            loadXml(this, data);    
        }
        public static MyClass LoadXml(data)
        {
            var output = new MyClass();
            loadXml(output, data);
            return output;
        }
        private static void loadXml(MyClass classToInitialize, XElement data)
        {
            // your loading code goes here
        }
    }
