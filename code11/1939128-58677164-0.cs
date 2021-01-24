    public class Game
    {
        public int GameId { get; set; }
        public int GenreId { get; set; }
    }
    
    var list = new List<Game>{
        new Game { GameId = 1, GenreId = 1 },
        new Game { GameId = 2, GenreId = 1 },
        new Game { GameId = 2, GenreId = 2 },
        new Game { GameId = 3, GenreId = 1 },
        new Game { GameId = 3, GenreId = 2 },
        new Game { GameId = 4, GenreId = 1 },
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
