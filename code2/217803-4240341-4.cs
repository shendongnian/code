    var teamGameLookup = Games.ToLookup(x => x.TeamID);
    
    var twoDayApartGames = from game in Games
                           join secondGame in teamGameLookup[game.TeamID]
                           on game.GameDate.Date equals secondGame.GameDate.Date.AddDays(2)
                           select new { Game = game, GameTwoDaysEarlier = secondGame };
