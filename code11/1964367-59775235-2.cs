    public abstract class Game
    {
        public IEnumerable<int> ListOfItemss { get; } = new List<int>();
        protected Game()
        {
        }
        protected Game(string gameInput)
        {
            var gameParser = new GameParser();
            ListOfItemss = gameParser.ParseGameInputString(gameInput);
        }
        public abstract int Bowl(int items);
    }
