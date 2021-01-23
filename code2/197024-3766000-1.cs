    class Program
    {
        static void Main(string[] args)
        {
            Example<IDictionary<int, string>>.IsDictionary();
            Example<SortedDictionary<int, string>>.IsDictionary();
            Example<Dictionary<int, string>>.IsDictionary();
            Console.ReadKey();
        }
    }
    public class Example<T>
    {
        public static void IsDictionary()
        {
            if (typeof(T).GetInterface(typeof(IDictionary<,>).Name) != null || typeof(T).Name.Contains("IDictionary"))
            {
                Console.WriteLine("Is IDictionary");
            }
            else
            {
                Console.WriteLine("Not IDictionary");
            }
        }
    }
