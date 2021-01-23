    public class StackOverflow_7374609
    {
        [XmlRoot(ElementName = "MyType", Namespace = "")]
        public class MyType
        {
            [XmlText]
            public string Value;
        }
        static void PrintChars(string str)
        {
            string toEscape = "\r\n\t\b";
            string escapeChar = "rntb";
            foreach (char c in str)
            {
                if (' ' <= c && c <= '~')
                {
                    Console.WriteLine(c);
                }
                else
                {
                    int escapeIndex = toEscape.IndexOf(c);
                    if (escapeIndex >= 0)
                    {
                        Console.WriteLine("\\{0}", escapeChar[escapeIndex]);
                    }
                    else
                    {
                        Console.WriteLine("\\u{0:X4}", (int)c);
                    }
                }
            }
            Console.WriteLine();
        }
        public static void Test()
        {
            string serialized = "<MyType>Hello\r\nworld</MyType>";
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(serialized));
            XmlSerializer xs = new XmlSerializer(typeof(MyType));
            MyType obj = (MyType)xs.Deserialize(ms);
            Console.WriteLine("Without the replacement");
            PrintChars(obj.Value);
            serialized = serialized.Replace("\r", "&#xD;");
            ms = new MemoryStream(Encoding.UTF8.GetBytes(serialized));
            obj = (MyType)xs.Deserialize(ms);
            Console.WriteLine("With the replacement");
            PrintChars(obj.Value);
        }
    }
