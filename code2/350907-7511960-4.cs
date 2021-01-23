    class Program
    {
        static void Main(string[] args)
        {
            AnotherClass c = new AnotherClass();
            
            c.List.Add("aaa");
            Console.WriteLine(c.ReadonlyList[0]); // prints "aaa"
            c.List.Add("bbb");
            Console.WriteLine(c.ReadonlyList[1]); // prints "bbb"
            Console.Read();
        }
    }
