    public void SetColorizationCollectionForShader()
    {
        var coloredTilesArray = Battlemap.Instance.tiles.Where(
                x => x.selectionMode != TileSelectionMode.None).ToArray();
        int tileCountWidth = Battlemap.Instance.tileCountX;
        int tileCountHeight = Battlemap.Instance.tileCountZ;
        float leftMostTileX = 0f + Battlemap.HALF_TILE_SIZE;
        float backMostTileZ = 0f + Battlemap.HALF_TILE_SIZE;
        float rightMostTileX = leftMostTileVertexX + (tileCountWidth-1) 
                * Battlemap.HALF_TILE_SIZE * 2f;
        float forwardMostTileZ = backMostTileVertexZ + (tileCountHeight-1) 
                * Battlemap.HALF_TILE_SIZE * 2f;
     
        Texture2D colorTex = new Texture2D(tileCountWidth, tileCountHeight);
        colorTex.filterMode = FilterMode.Point;
        
        Vector4 worldRange = new Vector4(
                leftMostTileX - Battlemap.HALF_TILE_SIZE,
                backMostTileZ - Battlemap.HALF_TILE_SIZE,
                rightMostTileX + Battlemap.HALF_TILE_SIZE,
                forwardMostTileZ + Battlemap.HALF_TILE_SIZE);
        meshRenderer.material.SetVector4("_WorldSpaceRange", worldRange);
        // used to map from selectionMode to (0,0,0,1)/(1,0,0,1)/(0,1,0,1)/(0,0,1,1)
        Color[] selectionColors = new Color[4] {Color.black, Color.red, Color.green, Color.blue};
        // Loop through the tiles to be colored only and grab their world coordinates
        for(int i = 0; i < coloredTilesArray.Length; i++)
        {
            // determine pixel index from position
            float xT = Mathf.InverseLerp(leftMostTileX, rightMostTileX, coloredTilesArray[i].x);
            int texXPos = Mathf.RoundToInt(Mathf.Lerp(0f, tileCountWidth-1.0f, xT));
            float yT = Mathf.InverseLerp(backMostTileZ , forwardMostTileZ , coloredTilesArray[i].z);
            int texZPos = Mathf.RoundToInt(Mathf.Lerp(0f, tileCountHeight-1.0f, yT));
 
            colorTex.SetPixel(texXPos, texZPos, selectionColors[coloredTilesArray[i].selectionMode]);        
        }
        // Feed the color map into the shader
        meshRenderer.material.SetTexture("_ColorizeMap", colorTex);
    }
