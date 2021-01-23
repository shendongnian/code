    public class Module
    {
    
      public void Sort()
      {
          ClassInfoList = ClassInfoList.OrderBy( x=>x.BlocksCovered).ToList();
      }
    ..
    }
