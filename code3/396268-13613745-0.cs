    static class Program
    {
        private static IList<Func<int, int>> delegateList = 
            new List<Func<int, int>>()
        {
            AddOne, AddOne, AddOne, AddOne, AddOne,
            AddOne, AddOne, AddOne, AddOne, AddOne,
        };
        static void Main(string[] args)
        {
            int number = 12;
            Console.WriteLine("Starting number: {0}", number);
            Console.WriteLine("Ending number: {0}", 
                              delegateList.InvokeChainDelegates(number));
            Console.ReadLine();
        }
        public static int AddOne(int num) { return num + 1; }
        public static T InvokeChainDelegates<T>(this IEnumerable<Func<T, T>> source, 
                                                T startValue)
        {
            T result = startValue;
            foreach (Func<T, T> function in source)
            {
                result = function(result);
            }
            return result;
        }
    }
