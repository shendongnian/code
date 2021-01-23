    public class X<T>
    {
      private List<T> myList;
    
      public List<T> CheckConditions(params Func<T, bool>[] conditions)
      {
        IEnumerable<T> query = myList;
        foreach (Func<T, bool> condition in conditions)
        {
          query = query.Where(condition);
        }
        return query.ToList();
      }
    }
    
