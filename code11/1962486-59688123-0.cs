    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.c = "1";
            obj.r = "2";
            obj.p = "3";
            obj.v = "4";
            var serializer = new XmlSerializer(obj.GetType());
            string result;
            using (var writer = new System.IO.StringWriter())
            {
                serializer.Serialize(writer, obj);
                result = writer.ToString();
            }
            Debug.WriteLine(result);
        }
    }
