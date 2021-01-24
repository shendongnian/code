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
EDIT - for your comment on multiple contexts:
It's important that you call `context.SaveChanges ()` on all contexts. Only the instance of `context` knowns what has been changed and can generate the sql insert/update/delete statements. To make sure that different contexts (or even when you use only one context) will made database changes atomic you can use `TransactionScope` to make sure either all changes are written to the database or nothing happens at all. Example:
public void DoWork ()
{
    // make sure you have MSDTC configured otherwise the TransactionScope will not work.
    using (var scope = new TransactionScope ()) 
    {
        Action1 ();
        Action2 ();
        // This will persist it to the database - COMMIT
        scope.Complete (); 
    } 
}
public void Action1 ()
{
    using (var context = new DbContext ()) 
    {
        // Do some work...
        context.SaveChanges ();
    }
}
public void Action2 ()
{
    using (var otherContext = new DbContext ()) 
    {
        // Do some work...
        otherContext.SaveChanges ();
    }
}
