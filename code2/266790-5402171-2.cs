    class Program
    {
        static void Main(string[] args)
        {
            string s;
            s = System.Xml.XmlConvert.EncodeName("valid XML --> !@#$%^&*()");
            Console.WriteLine("Encoded: {0}", s);
            Console.WriteLine("Decoded: {0}",System.Xml.XmlConvert.DecodeName(s));
            Console.ReadLine();
        }
    }
