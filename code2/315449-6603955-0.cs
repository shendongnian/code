    interface ICanAdd
    {
        int Value { get; }
        public static int operator+ (ICanAdd lvalue, int rvalue)
        {
            Console.WriteLine("this works in C# 8");
            return lvalue.Value + rvalue;
        }
    }
    class Add : ICanAdd
    {
        public int Value => 0;
    }
    class Program
    {
        static void Main(string[] args)
        {
            ICanAdd poo = new Add();
            var x = poo + 0;
            Console.WriteLine(x);
        }
    }
