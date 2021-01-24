public class Player
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Player FirstName is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Team Name is required")]
    public string LastName { get; set; }
    public Team Team { get; set; }
}
public class Team
{
    public long Id { get; set; }
    [Required(ErrorMessage ="Team Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Team Location is required")]
    public string Location { get; set; }
    public ICollection<Player> PlayerList { get; set; }
}
To add a `Player` to a `Team` something like that is needed:
var team =  await context.Teams.FindAsync (teamId);
var player = new Player { FirstName = "firstname", LastName = "lastname" };
team.PlayerList.Add (player);
context.SaveChanges ();
You don't need to set the `team` state to `Modified` because nothing has changed that needs to be commited to the database. Only the `player` will be inserted in the database.
