    public enum MaterialType
    {
        Wood,
        Stone,
        Count // this should always be the last one
    }
    public class Block
    {
        MaterialType m_type;
    }
    public class Player
    {
        MaterialType m_inventory[MaterialType.Count];
    }
    // call this when you break a block
    public class World
    {
        public void OnBlockDestroyed()
        {
            player.m_inventory[block.m_type]++;
        }
    }
