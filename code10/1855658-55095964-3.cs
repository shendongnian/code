        public class Dice
        {
            private static readonly Random random = new Random();
            public int Result
            {
                get;
                private set;
            }
            public void Roll()
            {
                lock ( random )
                    Result = random.Next(1, 7);
            }
        }
    
        public static void Main()
        {
            var dice = new Dice();
            dice.Roll();
            var player1Result = dice.Result;
            Console.WriteLine("Player 1 rolls: " + player1Result);
            dice.Roll();
            var player2Result = dice.Result;
            Console.WriteLine("Player 2 rolls: " + player2Result);
        }
    (try it [here](https://dotnetfiddle.net/BEO04U))
    Notice that I've assigned a variable for each roll - this enables you to `compare` the results using `>` and `<` to find out who wins.
