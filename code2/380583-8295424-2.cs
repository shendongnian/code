        static void Main(string[] args)
        {
            string xml = @"<MyClass>
            <Name>Test</Name>
            <Bytes>U2NhcnkgQnVnZ2Vy</Bytes>
             </MyClass>";
            MyClass obj = (MyClass)Deserialize(xml);
            Console.ReadKey();
        }
