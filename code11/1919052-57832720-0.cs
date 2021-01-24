    public class Program
    {
        public Console.Color DefaultColor { get; set; } => Console.Color.Black;
    
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("example");
            Console.ForgroundColor = DefaultColor;
    
        }   
    }
