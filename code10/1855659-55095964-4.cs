        public class Dice
        {
            private static readonly Random random = new Random();
            private readonly int _minValue;
            private readonly int _maxValue;
            public Dice(int minValue, int maxValue)
            {
                _minValue = minValue;
                _maxValue = maxValue;
            }
            public int Result
            {
                get;
                private set;
            }
            public void Roll()
            {
                lock ( random )
                    Result = random.Next(_minValue, _maxValue + 1);
            }
        }
        public static void Main()
        {
            var player1Dice = new Dice(1, 6);
            player1Dice.Roll();
            var player1Result = player1Dice.Result;
            Console.WriteLine("Player 1 rolls: " + player1Result);
            var player2Dice = new Dice(1, 5);
            player2Dice.Roll();
            var player2Result = player2Dice.Result;
            Console.WriteLine("Player 2 rolls: " + player2Result);
        }
    (try it [here](https://dotnetfiddle.net/LOleo6))
    You can still do comparisons, but because you have different `Dice` instances, you could add your own constructor to `Dice` to, for instance, stack the odds in favour of one player (here I've made the second player's dice only ever roll 1-5).
