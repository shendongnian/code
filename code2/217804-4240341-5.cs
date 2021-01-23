     var teamGameLookup = Games.ToLookup(x => x.TeamID);
    
        var seperatedGames = from game in Games
                             join otherGame in teamGameLookup[game.GameID]
                             on DatesWithinRange(game.GameDate,otherGame.GameDate,2,25) equals true
                             let daysApart = (game.GameDate - otherGame.GameDate).TotalDays
                             select new { Game = game, OtherGame = otherGame, DaysApart = daysApart};
    
        private bool DatesWithinRange(DateTime firstDate, DateTime secondDate, float lower, float higher)
        {
             float elapsedDays = (secondDate - firstDate).TotalDays;
             return elapsedDays >= lower && elapsedDays <= higher;
        }
