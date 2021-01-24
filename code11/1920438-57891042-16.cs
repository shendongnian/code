    public class GridMap : MonoBehaviour
    {
        public Transform Map;
        public Tile[,] GridMatrix = new Tile[6,6];
        private Tile[] MyVector = new Tile[36];
    
        // I would move it all to Awake
        //   1. it is possible so why wait until Start
        //   2. Makes also sure that the Start method of GetPlayerPosition
        //      will definitely be executed after all this
        //      => makes sure the array will actually be filled already! 
        private void Awake()
        {
            for (int i = 0; i < 36; i++)
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
    
            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    GridMatrix[i, j] = MyVector[i * 6 +j];
                    GridMatrix[i, j].TilePosition = new Vector2Int (i, j);
                }
            }
        }
    }
