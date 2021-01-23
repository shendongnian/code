    public class Module
    {
    
      public void Sort()
      {
          ClassInfoList.OrderBy( x=>x.BlocksCovered).ToList();
      }
    ..
    }
