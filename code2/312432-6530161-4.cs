        public class Program
        {
            public class MyData
            {
                public string MyStringField { get; set; }
                public int MyIntField { get; set; }
            }
            public static void Main()
            {
                var data = new MyData { MyStringField = "Test", MyIntField = 1 };
                var serializer = new XmlSerializer(typeof(MyData));
                using (var stream = new StreamWriter("C:\\test.xml"))
                    serializer.Serialize(stream, data);
            }
        }
