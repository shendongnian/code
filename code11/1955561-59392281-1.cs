    public static class Program
    {
        public static void Main()
        {
            var rawData = @"Guest 450
    Ryan 300
    Ryan 4850
    Ryan 100
    Guest 300
    Guest 1800";
            var players = rawData
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(row => row.Split())
                .Select(elements => new Player { Name = elements[0], Score = int.Parse(elements[1]) })
                .ToList();
            players.Sort(PlayerComparer.Default);
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }
    }
    public class PlayerComparer : IComparer<Player>
    {
        public static readonly IComparer<Player> Default = new PlayerComparer();
        public int Compare(Player x, Player y)
        {
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            var scoreComparison = y.Score - x.Score;
            if (scoreComparison != 0)
                return scoreComparison;
            return StringComparer.OrdinalIgnoreCase.Compare(x.Name, y.Name);
        }
    }
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public override string ToString() => $"{Name} {Score}";
    }
