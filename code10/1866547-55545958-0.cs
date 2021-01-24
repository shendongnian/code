                string games = "Name: game1, StatusName Name: game2,";
                var splittedText = games.Split(':');
                var currentGame = splittedText.Select(x => x.Length > 4 ? x.Substring(1, 5) : "")
                    .Where(y => y != "")
                    .Distinct()
                    .ToList();
