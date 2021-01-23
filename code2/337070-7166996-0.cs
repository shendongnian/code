    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    
    namespace GamesLib
    {
        public class Game
        {
            public string HomeTeam { get; private set; }
            public string AwayTeam { get; private set; }
            public string HomeScore { get; private set; }
            public string AwayScore { get; private set; }
    
            public string Combined
            {
                get
                {
                    return " " + HomeTeam + " " + HomeScore + " - " + AwayScore + " " + AwayTeam;
                }
            }
    
            public Game(string HomeTeam, string AwayTeam, string HomeScore, string AwayScore)
            {
                this.HomeTeam = HomeTeam;
                this.HomeScore = HomeScore;
                this.AwayTeam = AwayTeam;
                this.AwayScore = AwayScore;
            }
        }
    
        public class Games : List<Game>, INotifyPropertyChanged
        {
            public string CombinedTeams
            {
                get
                {
                    var str = "";
                    foreach (Game g in this)
                    {
                        str += g.Combined;
                    }
                    return str;
                }
            }
    
            public new void Add(Game g)
            {
                base.Add(g);
                if ( PropertyChanged != null ) {
                    PropertyChanged(this, new PropertyChangedEventArgs("CombinedTeams"));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
