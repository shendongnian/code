    public static IEnumerable<ListItemCollectionPosition> GetPositions()
    {            
         do           
         {
           ...
           yield return pos;
           ...
         } while (pos != null);
    }
