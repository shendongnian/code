    public void DeleteExistingTile()  
    {  
        var foundTile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("DetailId=123"));  
      
        // If the Tile was found, then delete it.  
        if (foundTile != null)  
        {  
            foundTile.Delete();  
        }  
    }  
