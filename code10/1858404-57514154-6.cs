    class Program
    {
        private static readonly Guid sFld = default(Guid);
        private readonly DateTime iFld = default(DateTime);
        static void Main(string[] args)
        {
            new Program().Run("a string");
        }
        private void Run(string arg)
        {
            int loc = 42;
            Method(p1: loc, p2: arg, p3: sFld, p4: iFld);
        }
        private void Method(int p1, string p2, object p3, DateTime p4)
        {
            Console.WriteLine(VariableHelper.ResolveArgument(p1));
            Console.WriteLine(VariableHelper.ResolveArgument(p2));
            Console.WriteLine(VariableHelper.ResolveArgument(p3));
            Console.WriteLine(VariableHelper.ResolveArgument(p4));
        }
    }
