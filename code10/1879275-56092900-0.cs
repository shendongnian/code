    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                Player newPlayer = null;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        string[] splitLine = line.Split(new char[] { ':' }).ToArray();
                        if (line.StartsWith("Name"))
                        {
                            newPlayer = new Player();
                            Player.players.Add(newPlayer);
                            newPlayer.name = splitLine[1].Trim();
                        }
                        else
                        {
                            if (line.StartsWith("Score"))
                            {
                                if (newPlayer.scores == null) newPlayer.scores = new List<int>();
                                newPlayer.scores.Add(int.Parse(splitLine[1]));
                            }
                        }
                    }
                }
                string[] playersNames = Player.players.Select(x => x.name).ToArray();
                Console.WriteLine(string.Join(" , ", playersNames));
                Console.ReadLine();
            }
        }
        public class Player
        {
            public static List<Player> players = new List<Player>();
            public string name { get; set; }
            public List<int> scores { get; set; }
        }
    }
