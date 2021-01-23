    class Program
    {
        static void Main()
        {
            PdfReader reader = new PdfReader("test.pdf");
            var title = reader.Info["Title"];
            Console.WriteLine(title);
        }
    }
