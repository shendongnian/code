    public class LimitedList<T> : List<T> {
    
      public void Add(T item) {
        if (Count == 20) {
          RemoveAt(0);
        }
        base.Add(item);
      }
    
    }
