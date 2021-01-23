    try
    {
        manager = new ComObjectClass();
        ComObject comObject = null;
        ComObject[] collectionOfComItems = manager.GetCollectionOfItems();
        try
        {
            for(int i = 0; i < collectionOfComItems.Count; i++)
            {
                comObject = collectionOfComItems[i];
                ReleaseComObject(comObject);
            }
        }            
        finally
        {
            ReleaseComObject(comObject);
        }
    }
    finally 
    {
        ReleaseComObject(manager);
    }
