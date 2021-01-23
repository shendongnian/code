    class Program
    {
        static void Main(string[] args)
        {
            List<Action> actions = new List<Action>();
            List<Game> gamesForStats = new List<Game>();
            List<Player> playersForStats = new List<Player>();
            List<Action> result = (from oAction in actions
                                   join game in gamesForStats on oAction.Game equals game.GameName
                                   join player in playersForStats on oAction.Player equals player.PlayerName
                                   select oAction).ToList();
            Console.ReadLine();
        }
    }
    public class Player
    {
        public string PlayerName { get; set; }
    }
    public class Game
    {
        public string GameName { get; set; }
    }
    public class Action
    {
        public string Player { get; set; }
        public string Game { get; set; }
        public string Type { get; set; }
    }
