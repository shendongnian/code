    Quoting @Yuck who answered the first question perfectly.
    
    C# code for the first part of your question:
    
        // N = Initial Team Count
        // R = Zero-Based Round #
        // Games = (N / (2 ^ R)) / 2
        public double GamesPerRound(int totalTeams, int currentRound) {
            var result = (totalTeams / Math.Pow(2, currentRound)) / 2;
        
            // Happens if you exceed the maximum possible rounds given number of teams
            if (result < 1.0F) throw new InvalidOperationException();
        
            return result;
        }
    
    Moving on to the second question:
    
        //G = current game.
        //TGR = Total Games in current Round.
        //T = total teams
        //Next round game = TGR + RoundedUp(G / 2)
        //i. e.: G = 2, TGR = 4
               //Next round game = 4 + RoundedUp(2 / 2) = 5
        public int NextGame(int totalTeams, int currentGame, int currentRound) {
            return GamesPerRound(totalTeams, currentRound) + (int)Math.Ceiling((double)currentGame / 2);
        }
