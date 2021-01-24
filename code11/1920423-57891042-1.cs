    public Tile[,] GridMatrix;
    void Awake()
    {
        for (int i = 0; i < 36; i++)
        {
            try
            {
                MyVector[i] = Map.transform.GetChild(i).GetComponent<Tile>();
            }
            catch
            {
                print("Something is wrong!");
            }
        }
    
        int Counter = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GridMatrix[i, j] = MyVector[Counter];
                Counter;
                GridMatrix[i, j].TilePosition = new Vector2Int (i, j);
            }
        }
    }
