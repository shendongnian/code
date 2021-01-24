    // Will be set if triggering a Tile
    public Vector2Int PlayerPosition;
    void Start()
    {  
        map = FindObjectOfType<GridMap>();
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Tile tile = map.GridMatrix[i, j];
                tile.playerPosition = this;               
            }
        }
    }
