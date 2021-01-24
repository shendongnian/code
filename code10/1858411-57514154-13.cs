    class Program
    {
        private static readonly Guid sFld1 = default(Guid);
        private readonly DateTime iFld1 = default(DateTime);
        private static readonly Guid sFld2 = default(Guid);
        private readonly DateTime iFld2 = default(DateTime);
        static void Main(string[] args)
        {
            new Program().Run("_1", "_2");
        }
        private void Run(string arg1, string arg2)
        {
            int loc1 = 42;
            int loc2 = 24;
            Console.WriteLine("\tFirst call");
            Method(p1: loc1, p2: arg1, p3: sFld1, p4: iFld1);
            Console.WriteLine("\tSecond call");
            Method(p1: loc2, p2: arg2, p3: sFld2, p4: iFld2);
        }
        private void Method(int p1, string p2, object p3, DateTime p4)
        {
            Console.WriteLine(VariableHelper.ResolveArgument(p1));
            Console.WriteLine(VariableHelper.ResolveArgument(p2));
            Console.WriteLine(VariableHelper.ResolveArgument(p3));
            Console.WriteLine(VariableHelper.ResolveArgument(p4));
        }
    }
