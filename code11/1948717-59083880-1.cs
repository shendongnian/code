    public class Program
    {
        public static Game game1 {get; set;}
        static void Main(string[] args)
        {
            game1 = new Game();
            game1.SetQuestion1(GetInput());
            game1.game();
            game1.DisplayAll();
        }
        public static string GetInput()
        {
            string input = "";
            do
            {
                WriteLine("Please enter your choice: Rock - 1, Paper - 2, Scissors - 3");
                input = ReadLine();
            }
            while (game1.win < 4 || game1.lose < 4 || game1.usermoney == 0);
            return input;
        }
    }
