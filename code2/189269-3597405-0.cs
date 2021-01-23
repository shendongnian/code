    namespace Play
    {
        public static class LinqExtensions {
            public static U JoinElements<T, U>(this IEnumerable<T> list, Func<T, U> initializer, Func<U, T, U> joiner)
            {
                U joined = default(U);
                bool first = true;
                foreach (var item in list)
                {
                    if (first)
                    {
                        joined = initializer(item);
                        first = false;
                    }
                    else
                    {
                        joined = joiner(joined, item);
                    }
                }
                return joined;
            }
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                List<int> nums = new List<int>() { 1, 2, 3 };
                var sum = nums.JoinElements(a => a, (a, b) => a + b);
                Console.WriteLine(sum); // outputs 6
    
                List<string> words = new List<string>() { "a", "b", "c" };
                var buffer = words.JoinElements(
                    a => new StringBuilder(a), 
                    (a, b) => a.Append(",").Append(b)
                    );
    
                Console.WriteLine(buffer); // outputs "a,b,c"
    
                Console.ReadKey();
            }
    
        }
    }
