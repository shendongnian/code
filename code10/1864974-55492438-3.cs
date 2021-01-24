    class Program
    {
        static void Main(string[] args)
        {
    #nullable enable
            string? message = "Hello World";
    #nullable disable
            string message2 = null;
    
            Console.WriteLine(message);
            Console.WriteLine(message2);
        }
    }
