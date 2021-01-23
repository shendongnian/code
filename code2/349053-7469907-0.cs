    public class LockedCollection<T> : ICollection<T>
    {
       private readonly object _lock = new object();
       private readonly List<T> _list = new List<T>();
    
       public void Add(T item)
       {
          lock (_lock)
          {
             _list.Add(item);
          }
       }
    
       // other members ...
    
    }
