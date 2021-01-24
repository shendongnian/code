    public class Game
    {
        public string GameId { get; set; }
        public string GenreId { get; set; }
    }
    
    var list = new List<Game>{
        new Game { GameId = "Final Fantasy VII", GenreId = "RPG" },
        new Game { GameId = "Dark Souls", GenreId = "RPG" },
        new Game { GameId = "Dark Souls", GenreId = "Action" },
        new Game { GameId = "World of Warcraft", GenreId = "MMORPG" },
        new Game { GameId = "Resident Evil 2", GenreId = "Survival" },
        new Game { GameId = "Resident Evil 2", GenreId = "Horror" }
    };
    
    var groupedList = list.GroupBy(
        g => g.GameId,
        g => g.GenreId,
        (key, group) => new
            {
                GameId = key,
                Genres = group.ToList()
            })
         .ToList();
