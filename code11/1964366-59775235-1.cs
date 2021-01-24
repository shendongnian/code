    public abstract class Game
    {
        public List<int> ListOfItemss { get; } = new List<int>();
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
