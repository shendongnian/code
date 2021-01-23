    namespace ConsoleApplication46
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var d = new Dictionary<string, int>();
    
                d.Add(null, 1);
    
                Console.WriteLine(d["adam"]);
                Console.Read();
            }
        }
    }
