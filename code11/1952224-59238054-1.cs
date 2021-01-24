csharp
var favGames = favCollection.AsQueryable()
                            .Where(fg=> fg.UserID== "xxxxxxxxxxx")
                            .Join(gameCollection.AsQueryable(), //foreign collection
                                  fg => fg.GameID,              //local field
                                  gm => gm.ID,                  //foreign field
                                  (fg, gm) => new { gm.Title }) //projection
                            .ToList();
with aggregate interface:
csharp
public class JoinedGameModel
{
    public GameModel[] Results { get; set; }
}
csharp
var favGames = favGameCollection.Aggregate()
                   .Match(fg => fg.UserID == "xxxxxxxxxxxx")
                   .Lookup<FavouriteGameModel, GameModel, JoinedGameModel>(
                       gameCollection, 
                       fg => fg.GameID, 
                       gm => gm.ID, 
                       jgm => jgm.Results)
                   .ReplaceRoot(jgm => jgm.Results[0])
                   .Project(gm => new { gm.Title })
                   .ToList();
