    for (int x = 0; x < width; x++)
             {
                 for (int y = 0; y < height; y++)
                 {                
                     Vector3 tempPosition = camera.ViewportToWorldPoint(new Vector3(x, y, camera.nearClipPlane));                    
                     GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity,this.transform) as GameObject;
  
                     backgroundTile.name = "( " + x + "," + y + ")";
    
                     allTiles[x, y] = backgroundTile;               
                 }
             }
