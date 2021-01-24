        static void Main(string[] args)
        {
            var nvc = new NameValueCollection {{"5", "first value"}, {"6", "second value"}, {"9", "third value"}};
            Console.WriteLine(nvc["5"]); // first value
            Console.WriteLine(nvc[1]);   // second value
            Console.WriteLine(nvc[3]);   // index was out of range
        }
