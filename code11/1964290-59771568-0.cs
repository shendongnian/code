    public class Program
    {
        private const int MAX_LENGTH = 50;
        static void Main(string[] args)
        {
            var less = GeneratedLessThan(12);
            var more = GeneratedMoreThan(12);
            Console.WriteLine($"Less Than : {less} ({less.Length})");
            Console.WriteLine($"More Than : {more} ({more.Length})");
            Console.ReadLine();
        }
    
        static char[] ABC()
        {
            List<char> list = new List<char>();
            for (char i = 'A'; i <= 'Z'; i++)
            {
                list.Add(i);
            }
            return list.ToArray();
        }
    
        static string GeneratedLessThan(int max) => GeneratedString(0, max);
        static string GeneratedMoreThan(int min) => GeneratedString(min, MAX_LENGTH);
        static string GeneratedString(int min, int max)
        {
            StringBuilder builder = new StringBuilder();
            var abc = ABC();
            var rnd = new Random();
            for (int i = 0; i <= rnd.Next(min, max); i++)
            {
                builder.Append(abc[rnd.Next(abc.Length)]);
            }
    
            return builder.ToString();
        }
    }
