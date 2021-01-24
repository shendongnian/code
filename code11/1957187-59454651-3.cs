    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(SomeClass.GetId(3));
        }
    }
    static class SomeClass
    {
        static SomeClass()
        {
            Console.WriteLine(GetId(1));
            Console.WriteLine(GetId(2));
        }
        public static string GetId(int Id) { return Id.ToString(); }
    }
