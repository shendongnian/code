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
            ICanAdd foo = new Add();
            var x = foo + 1;
            Console.WriteLine(x);
        }
    }
