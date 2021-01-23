    var lastPlayedQuery = (from game in Game
                          group game by game.TeamID into g
                          let lastPlayedDate = g.Select(x => x.GameDate).Max()
                          select new { TeamID = game.TeamID, LastPlayedDate = lastPlayedDate }).ToDictionary(x => x.TeamID, x => x.LastPlayedDate);
    var gamesTwoDaysLater = from game in Games
                            let lastPlayedDate = lastPlayedQuery[game.TeamID]
                            let elapsedDays = (game.GameDate - lastPlayedDate).TotalDays
                            where elapsedDays >= 2.00 && elapsedDays < 3.00
                            select game;
