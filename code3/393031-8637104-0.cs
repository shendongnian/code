    public interface IPlayer {}
    
    public abstract class Player : IPlayer 
    {
      public ITournament CurrentTournament { get; set; }
    }
    
    public class PokerPlayer : Player 
    {
      private PokerPlayer() {}
      public PokerPlayer(int startingChips)
      { 
        if(startingChips < 1) throw new ArgumentException("Invalid starting amount.", "startingChips");
        this.StartingChips = startingChips; 
      }
      public int StartingChips { get; set; }
      public int CurrentChips { get; set; }
    
      public double StackPercentage 
      {
        get { return this.CurrentChips / this.StartingChips; }
      }
    }
    
    public interface ITournament {}
    
    public abscract class Tournament : ITournament
    {
      public List<Player> Players { get; set; }
      public int PlayerCount { get { return this.Players.Count; } }
    }
    
    public class PokerTournament : Tournament 
    {
      
    }
