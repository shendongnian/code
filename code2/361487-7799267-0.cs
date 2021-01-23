    using DTO = MyDTONamespace;
    
    namespace MyServiceNamespace {
      public class MyService {
        [WebGet(UriTemplate = "")]
        public IQueryable<DTO.Game> GetGames() {
          var db = new XBoxGames();
          var games = db
              .Games
              .Include("Genre")
              .Include("Rating")
              .OrderBy(g => g.Id)
              .ToList();
          var gamesDTO = Mapper.Map<List<Game>, List<DTO.Game>>(games);
          return gamesDTO.AsQueryable();
        }
      }
    }
