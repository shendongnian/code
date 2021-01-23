    var games = new List<Game> {
                    new Game { Name = "Foo Bros.", Players = 2, ReleaseYear = 1983 },
                    new Game { Name = "Hope", Players = 4, ReleaseYear = 1993 }
                };
    var firstFourPlayerGame = games.First(g => g.Players == 4);
    Console.WriteLine(firstFourPlayerGame.Name);
