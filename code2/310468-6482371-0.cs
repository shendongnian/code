    public abstract class GameObject
    {
            public GameObject();
    }
    public class TileStuff : GameObject
    {
        public TileStuff()
        {
        }
    }
    public class MoreTileStuff : GameObject
    {
        public MoreTileStuff()
        {
        }
    }
    public class Game
    {
        static void Main(string[] args)
        {
            GameObject[] arr = new GameObject[2];
            arr[0] = new TileStuff();
            arr[1] = new MoreTileStuff();
        }
    }
