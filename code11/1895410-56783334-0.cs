csharp
using MongoDB.Entities;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        [Name("Scores")]
        public class Score : Entity
        {
            public Coordinate[] Coordinates { get; set; }
            public string Player { get; set; }
            public float Time { get; set; }
            public string Level { get; set; }
        }
        public class Coordinate
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            var coords = new[] {
                new Coordinate{ x=1.111f, y=2.222f, z=3.333f},
                new Coordinate{ x=1.111f, y=2.222f, z=3.333f},
                new Coordinate{ x=1.111f, y=2.222f, z=3.333f}
            };
            (new[] {
                new Score
                {
                    Coordinates = coords,
                    Player = "player 1",
                    Time = 0.11f,
                    Level = "scene a"
            },  new Score
                {
                    Coordinates = coords,
                    Player = "player 2",
                    Time = 0.22f,
                    Level = "scene a"
                }
            }).Save();
            var scores = DB.Queryable<Score>()
                           .Where(s => s.Level == "scene a")
                           .OrderByDescending(s => s.Time)
                           .ToArray();
            foreach (var score in scores)
            {
                Console.WriteLine($"player: {score.Player}");
            }
            Console.ReadKey();
        }
    }
}
[disclaimer: i'm the author of the library]
