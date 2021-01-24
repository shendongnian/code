    public interface IMonopolySquare
    {
         public string Name { get; }
         public void PlayerLandsOnEvent(Player player);
         public void PlayerPassesSquareEvent(Player player);
         public void SetOwner(Player player);
    }
    public class GoSquare : IMonopolySquare
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
        public void SetOwner(Player player)
        {
            throw new Exception ("You can't buy go!!");
        }
    }
    public class PropertySquare : IMonopolySquare
    {
        private Player _owner = null;
        private int _rentWithoutHouse;
        private Color _color;
        public PropertySquare(
            string name,
            int rentWithoutHouse,
            Color color)
        {
            Name = name;
            _rentWithoutHouse = rentWithoutHouse;
            _color = color;
        }
        public string Name {get;}
         public void PlayerLandsOnEvent(Player player)
         {
             if (_owner != null && _owner != player)
             {
                 player.SubtractMoney(_rentWithoutHouse); 
             }
         }
         public void PlayerPassesSquareEvent(Player player)
         {
             // Do nothing.
         }
        public void SetOwner(Player player)
        {
            if (owner != null)
            {
                throw new Exception("Can't buy something that's already been bought!");
            }
            else
            {
                _owner = player;
            }
        }
    }
    // the Player class is left as an exercise for the reader...
