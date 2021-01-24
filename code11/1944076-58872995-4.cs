csharp
using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var blocks = new List<Block>
            {
                new Block
                {
                    End = new DateTime(1899, 12, 30, 11, 45, 0), Start = new DateTime(1899, 12, 30, 8, 30, 0)
                },
                new Block
                {
                    End = new DateTime(1899, 12, 30, 17, 0, 0), Start = new DateTime(1899, 12, 30, 13, 15, 0)
                }
            };
            var presences = new List<Presence>
            {
                new Presence
                {
                    Arrival = new DateTime(1899, 12, 30, 8, 3, 0),
                    Departure = new DateTime(1899, 12, 30, 9, 21, 0)
                },
                new Presence
                {
                    Arrival = new DateTime(1899, 12, 30, 9, 36, 0),
                    Departure = new DateTime(1899, 12, 30, 10, 34, 0)
                },
                new Presence
                {
                    Arrival = new DateTime(1899, 12, 30, 10, 45, 0),
                    Departure = new DateTime(1899, 12, 30, 12, 5, 0)
                },
                new Presence
                {
                    Arrival = new DateTime(1899, 12, 30, 13, 3, 0),
                    Departure = new DateTime(1899, 12, 30, 14, 24, 0)
                },
                new Presence
                {
                    Arrival = new DateTime(1899, 12, 30, 14, 34, 0),
                    Departure = new DateTime(1899, 12, 30, 16, 14, 0)
                },
                new Presence
                {
                    Arrival = new DateTime(1899, 12, 30, 16, 27, 0),
                    Departure = new DateTime(1899, 12, 30, 18, 2, 0)
                }
            };
            // group presence by blocks
            var group = new Dictionary<Block, List<Presence>>();
            foreach (var block in blocks)
            {
                group.Add(block, new List<Presence>());
                foreach (var presence in presences)
                {
                    if(presence.Departure >= block.Start && presence.Arrival <= block.End)
                        group[block].Add(presence);
                }
            }
            // calculate time per block
            foreach (var pair in group)
            {
                var block = pair.Key;
                var ps = pair.Value;
                for (int i = 0; i < ps.Count; i++)
                {
                    if (i + 1 < ps.Count)
                    {
                        Console.WriteLine($"{ps[i+1].Arrival} - {ps[i].Departure} = {(ps[i+1].Arrival - ps[i].Departure).Minutes}");
                    }
                }
            }
            
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
    public class Block
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    public class Presence
    {
        public DateTime Arrival   { get; set; }
        public DateTime Departure { get; set; }
    }
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/5vYuk.png
