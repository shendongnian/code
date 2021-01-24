    public interface IMonopolySquare
    {
         public string Name { get; }
         public void PlayerLandsOnEvent(Player player);
         public void PlayerPassesSquareEvent(Player player);
         public void SetOwner(Player player);
    }
    public class GoSquare
    {
         public string Name { get => "Go" }
         public void PlayerLandsOnEvent(Player player)
         {
              // Do nothing - player has to pass to receive £200.
         }
         public void PlayerPassesSquareEvent(Player player)
         {
             player.AddMoney(200);
         }
    }
