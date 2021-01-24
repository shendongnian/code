    public void ImportTiles() {
        ClonedTile clonedTile;
        int w_y = 0; // X coordinate in worldGraph
        for(int y = -height/2; y<height/2; y++ ) {
            int w_x = 0; // Y coordinate in worldGraph
            for (int x = -width/2; x<width/2; x++ ) {
                Vector3Int pos = new Vector3Int( x, y, 0 );
                TileBase tile = floor.GetTile(pos);
                if( tile != null ) {
                    clonedTile = new ClonedTile( w_x, w_y, TileType.Floor, false );
                    tiles[w_x, w_y] = clonedTile;
                    originalTiles.Add( clonedTile, tile );
                }
                tile = walls.GetTile( pos );
                if (tile != null ) {
                    clonedTile = new ClonedTile( w_x, w_y, TileType.Wall, false );
                    tiles[w_x, w_y] = clonedTile;
                    originalTiles.Add( clonedTile, tile );
                }
                tile = door.GetTile( pos );
                if(tile!= null ) {
                    clonedTile = new ClonedTile( w_x, w_y, TileType.Door, false );
                    tiles[w_x, w_y] = clonedTile;
                    originalTiles.Add( clonedTile, tile );
                }
                w_x++;
            }
            w_y++;
        }
    }
