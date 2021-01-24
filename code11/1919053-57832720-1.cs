    public class Program
    {
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.Black;
    
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("example");
            Console.ForegroundColor = DefaultColor;
    
        }   
    }
