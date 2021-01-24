    gameResults = gamerArray.GamePlayers.Select(g => new GameResult
                    {
                        GameID = g.GameID,
                        GameName = g.GameName,
                        SessionStart = g.StartTime,
                        SessionEnd = g.EndTime,
                        SessionMessage = "You Won!"
                    });
