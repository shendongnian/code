    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication106
    {
        class Program
        {
             static void Main(string[] args)
            {
                 List<Player> players = new List<Player>() {
                     new Player() { Name = "RRR", Points = 10 },
                     new Player() { Name = "CCC", Points = 10 },
                     new Player() { Name = "AAA", Points = 10 },
                     new Player() { Name = "YYY", Points = 8 },
                     new Player() { Name = "XXX", Points = 8 },
                     new Player() { Name = "ZZZ", Points = 7 },
                     new Player() { Name = "UUU", Points = 5 },
                     new Player() { Name = "QQQ", Points = 5 }
                 };
                 var groups = players.OrderBy(x => x.Points)
                     .Select((x, i) => new { rank = i + 1, player = x })
                     .GroupBy(x => x.player.Points).Select(x => new { rank = x.Min(y => y.rank).ToString() + "-" + x.Max(y => y.rank).ToString(), players = x.ToList()})
                     .ToList();
                 foreach (var group in groups)
                 {
                     group.players.First().player.Rank = group.rank;
 
                     //foreach (var player in group.players)
                     //{
                     //    player.player.Rank = group.rank;
                     //}
                 }
            }
     
        }
        class Player
        {
            public string Name
            { get; set; }
            public int Points
            { get; set; }
            public string Rank
            { get; set; }
        }
    }
