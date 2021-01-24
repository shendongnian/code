    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(test("Rofl"));
            Console.WriteLine(test("Camel"));
            Console.WriteLine(test("R"));
            Console.ReadLine();
        }
        public static string test(string value)
        {
            Regex r = new Regex("(?!^.)[a-zA-Z]+(?=.$)");
            var match = r.Match(value);
            if (match != null)
            {
                var result = r.Replace(value, match.ToString().ToUpper());
                return result;
            }
            return value;
        }
    }
