    public class PossibleLoots
    {
        private IList<Loot> _loots = new List<Loot>();
    
        public PossibleLoots(int maxLoots)
        {
            for (var i = 0; i < maxLoots; i++)
            {
                _loots.Add(new Loot(this.GetRandomPosition()));
            }
        }
    
        private Vector2 GetRandomPosition()
        {
            // Your logic here to create suitable locations for loot to appear
        }
    
        // Rest of your `PossibleLoots` code
        // to spawn each `Loot` and to deplete the `_loots`
        // collection when the player picks up each `Loot`
    }
