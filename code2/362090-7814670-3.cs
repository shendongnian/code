    class A
    {
        public string Z
        {
            get;
            set;
        }
        public int X
        {
            get;
            set;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A obj = new A();
            obj.Z = "aaa";
            obj.X = 15;
            Console.WriteLine(obj.Get<string>("Z"));
            Console.WriteLine(obj.Get<int>("X"));
            Console.ReadLine();
        }
    }
