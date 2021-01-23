    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GamesLib;
    
    namespace TestHarness
    {
        class Program
        {
            static void Main(string[] args)
            {
                var gs = new GamesLib.Games();
                gs.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(gs_PropertyChanged);
                var g = new Game("hometeam", "awayteam", "1", "0");
                gs.Add(g);
                g = new Game("lions", "bears", "1", "0");
                gs.Add(g);
                Console.WriteLine("Final result:" + gs.CombinedTeams);
            }
    
            static void gs_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                var gs = sender as Games;
                Console.WriteLine("Changed: " + gs.CombinedTeams);
            }
        }
    }
