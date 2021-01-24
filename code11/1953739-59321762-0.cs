    public void DrawLayer(int layer)
    {
    	for (var j = 0; j < curMap.Layers[layer].Tiles.Count; j++)
    	{
    		int gid = curMap.Layers[layer].Tiles[j].Gid;
    
    		if (gid == 0)
    		{ 
    			//empty tile
    		}
    		else
    		{
    			//draw your tile
    		}
    	}
    }
