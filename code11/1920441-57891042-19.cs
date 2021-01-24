    public class GridMap : MonoBehaviour
    {
        // just for clean coding reasons
        public const int GRID_WIDTH = 6;
        public const int GRID_HEIGHT = 6;
        public Transform Map;
        public Tile[,] GridMatrix = new Tile[GRID_WIDTH, GRID_HEIGHT];
        private Tile[] MyVector = new Tile[GRID_WIDTH * GRID_HEIGHT];
    
        // I would move it all to Awake
        //   1. it is possible so why wait until Start
        //   2. Makes also sure that the Start method of GetPlayerPosition
        //      will definitely be executed after all this
        //      => makes sure the array will actually be filled already! 
        private void Awake()
        {
            for (int i = 0; i < GRID_WIDTH * GRID_HEIGHT; i++)
            {
                try
                {
                    MyVector[i] = Map.GetChild(i).GetComponent<Tile>();
                }
                catch
                {
                    print("Something is wrong!");
                    return;
                }
            }
    
            for (var x = 0; x < GRID_WIDTH; x++)
            {
                for (var y = 0; y < GRID_HEIGHT; y++)
                {
                    // This depends of course on how you arranged the tiles in the hierarchy
                    GridMatrix[x, y] = MyVector[x * GRID_WIDTH + y];
                    GridMatrix[x, y].TilePosition = new Vector2Int (x, y);
                }
            }
        }
    }
