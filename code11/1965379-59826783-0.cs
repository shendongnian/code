    class Program
    {
        static void Main(string[] args)
        {
            string email = "test+{0:D3}@gmail.com";
            for (int i = 1; i < 101; i++)
            {
                Console.WriteLine(string.Format(email, i));
            }
        }
    }
