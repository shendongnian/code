    public class Program
    {
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.Black;
    
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("example");
            //You can use DefaultColor whenever you want to assign default color to Foreground
            Console.ForegroundColor = DefaultColor;
    
        }   
    }
