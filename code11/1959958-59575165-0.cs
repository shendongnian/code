    public class Program {
        public static void Main(string[] args) {
            var res = Randomise("12345");
            Console.WriteLine(res);
            Console.ReadKey();
        }
        public static string Randomise(string input)
        {
            string res = string.Empty;
            Random random = new Random();
            while (!string.IsNullOrEmpty(input)) {
                int num = random.Next(input.Length);
                res += input.Substring(num, 1);
                input = input.Remove(num, 1);
            } 
            return res;
        }
    }
