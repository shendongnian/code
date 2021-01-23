    public class MyList<T> : IMyItemsList, IMyGenericList<T> where T : IItem
    {
      public IEnumerable<T> GetList()
      {
        return null;
      }
    }
    
