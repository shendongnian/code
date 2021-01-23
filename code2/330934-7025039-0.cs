    static class Program
    {
        static void Main()
        {
            object obj = GetFinance();
            var financeInfo = obj.UnsafeCast(new
            {
                Item1 = default(decimal), Item2 = default(decimal),
                Item3 = default(decimal), Item4 = default(decimal),
                Item5 = default(decimal), Item6 = default(decimal)
            });
            System.Console.WriteLine(financeInfo.Item3); // 76
        }
        public static object GetFinance()
        {
            decimal x = 76;
            return new
            {
                Item1 = x, Item2 = x, Item3 = x,
                Item4 = x, Item5 = x, Item6 = x
            };
        }
    
        public static T UnsafeCast<T>(this object obj, T type)
        {
            return (T)obj;
        }
    }
