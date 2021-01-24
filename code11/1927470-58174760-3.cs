    public class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var chips = 21;
            var players = new List<Player>
            {
                new Player {Name = "Computer", IsComputer = true},
                new Player {Name = GetStringFromUser("Please enter your name: ")}
            };
            // Decide who goes first by choosing a number from 1 - 5. 
            // If it's less than 4, the user goes first
            var nextPlayer = rnd.Next(1, 6) < 4 ? 1 : 0;
            var previousPlayer = nextPlayer;
            while (chips > 0)
            {
                chips = players[nextPlayer].PlayTurn(chips);
                previousPlayer = nextPlayer;
                // Here we choose the next player simply 
                // by changing `1` to `0` (or `0` to `1`)
                nextPlayer = nextPlayer == 0 ? 1 : 0;
            }
            Console.WriteLine(players[previousPlayer].IsComputer
                ? "Congratulations, you won!"
                : "Sorry, you lost. Better luck next time!");
            GetKeyFromUser("\n\nDone! Press any key to exit...");
        }
        // These are helper methods I use to get input from the user
        private static string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        public static int GetIntFromUser(string prompt, Func<int, bool> validator = null)
        {
            int result;
            var cursorTop = Console.CursorTop;
            do
            {
                ClearSpecificLineAndWrite(cursorTop, prompt);
            } while (!int.TryParse(Console.ReadLine(), out result) ||
                        !(validator?.Invoke(result) ?? true));
            return result;
        }
    }
