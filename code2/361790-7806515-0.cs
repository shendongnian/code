    public class Team
    {
      private IList<Player> _players
      ...
    }
    
    public class Player
    {
      public string Name {get;set;}
    
      public abstract Influence { get; }
    }
    
    public class Forward : Player
    {
      public override Influence
      {
        get { return //calculation }
      }
    }
