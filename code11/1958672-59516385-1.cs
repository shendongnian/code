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
            int half = value.Length % 2 == 0 ? (value.Length / 2) - 1: (value.Length / 2);
            Regex r = new Regex("(?<=^.{"+ half + "})[a-zA-Z]{1,2}(?=.{"+ half + "}$)");
            var match = r.Match(value);
            if (match != null)
            {
                var result = r.Replace(value, match.ToString().ToUpper());
                return result;
            }
            return value;
        }
    }
