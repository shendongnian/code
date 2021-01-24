    public static bool isPropertyExist (dynamic d)
    {
      try {
           string check = d.folder.childCount;
           return true;
      } catch {
           return false;
      }
    }
    var newFolder = await {https://graph.microsoft.com/v1.0/me/drive/items/{itemID}}
    
    if (isPropertyExist(newFolder))
    {
      //Your code goes here.
    }
    
