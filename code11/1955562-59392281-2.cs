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
            var sortedPlayers = players
                .OrderByDescending(player => player.Score)
                .ThenBy(player => player.Name);
            foreach (var player in sortedPlayers)
            {
                Console.WriteLine(player);
            }
        }
    }
