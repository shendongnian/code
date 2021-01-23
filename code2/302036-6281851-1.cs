    class WorldChunk
    {
        String MyName;
        String[8] LinkedWorldChunkFileNames; 
        Tile[32,32] Tiles;
        void OnEnterFrame()
        {
            LoadWorldChunkFromName(MyName);
            foreach(name in LinkedWorldChunkFileNames)
            {
                LoadWorldChunkFromName(name);
            }
        }
        void LoadWorldChunkFromName(string name)
        {
            string fileData = LoadFromFile(name); //this should probably be done earlier, 
                                                  //when a neighbor loads it should load
                                                  // offscreen nieghbors
                                                  //files then parse them on its own enter                                        
                                                  //frame
            Tiles = ParseToTiles(fileData); //your own file parsing here
        }
        void OnExitFrame()
        {
            Tiles.Clear();
        }
    }
