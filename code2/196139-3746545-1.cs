    public class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("foo.txt"))
            {
                // Make sure you read from the file or it won't be able
                // to guess the encoding
                var file = reader.ReadToEnd();
                Console.WriteLine(reader.CurrentEncoding);
            }
        }
    }
