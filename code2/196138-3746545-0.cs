    public class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("foo.txt"))
            {
                Console.WriteLine(reader.CurrentEncoding);
            }
        }
    }
