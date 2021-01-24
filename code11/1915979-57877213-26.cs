        public void SetColorizationCollectionForShader()
    {   
        Color[] selectionColors = new Color[4] { Color.clear, new Color(0.5f, 0.5f, 0.5f, 0.5f), Color.blue, Color.red };
        float leftMostTileX = 0f + Battlemap.HALF_TILE_SIZE;
        float backMostTileZ = 0f + Battlemap.HALF_TILE_SIZE;
        float rightMostTileX = leftMostTileX + (Battlemap.Instance.GridMaxX - 1)
                * Battlemap.TILE_SIZE;
        float forwardMostTileZ = backMostTileZ + (Battlemap.Instance.GridMaxZ - 1)
                * Battlemap.TILE_SIZE;
        Texture2D colorTex = new Texture2D(Battlemap.Instance.GridMaxX, Battlemap.Instance.GridMaxZ);
        colorTex.filterMode = FilterMode.Point;
        Vector4 worldRange = new Vector4(
                leftMostTileX - Battlemap.HALF_TILE_SIZE,
                backMostTileZ - Battlemap.HALF_TILE_SIZE,
                rightMostTileX + Battlemap.HALF_TILE_SIZE,
                forwardMostTileZ + Battlemap.HALF_TILE_SIZE);
        meshRenderer.material.SetVector("_WorldSpaceRange", worldRange);        
        // Loop through the tiles to be colored only and grab their world coordinates
        for (int i = 0; i < Battlemap.Instance.tiles.Length; i++)
        {
            // determine pixel index from position
            float xT = Mathf.InverseLerp(leftMostTileX, rightMostTileX,
                    Battlemap.Instance.tiles[i].x);
            int texXPos = Mathf.RoundToInt(Mathf.Lerp(0f, Battlemap.Instance.GridMaxX - 1.0f, xT));
            float yT = Mathf.InverseLerp(backMostTileZ, forwardMostTileZ,
                    Battlemap.Instance.tiles[i].z);
            int texYPos = Mathf.RoundToInt(Mathf.Lerp(0f, Battlemap.Instance.GridMaxZ - 1.0f, yT));
            colorTex.SetPixel(texXPos, texYPos, selectionColors[(int)Battlemap.Instance.tiles[i].selectionMode]);
        }
        colorTex.Apply();
        // Feed the color map into the shader
        meshRenderer.material.SetTexture("_ColorizeMap", colorTex);
    }
There might be some wonkiness at the borders of the tiles, and there might be some alignment issues between texture space/world space but this should get you started.
