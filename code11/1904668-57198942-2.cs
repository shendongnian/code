    public class CoinFactory : MonoBehaviour
    {
        static CoinFactory instance;
        [SerializeField] Coin coinPrefab;
        void Awake()
        {
            instance=this;
        }
     
        public static Coin Create(Maze.CellCoordinates coords)
        {
            Coin coin = Instantiate(instance.coinPrefab);
            coin.Coords = coords;
            return coin;
        }
    }
