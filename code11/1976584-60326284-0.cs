    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Start--");
            Console.WriteLine("Enter value:");
            var x = Console.ReadLine();
            while(x != "a" && x != "b")
            {
                Console.WriteLine("Try again");
                x = Console.ReadLine();
            }
    
            Console.WriteLine("--End--");
            Console.Read();
        }
    }
