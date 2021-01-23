    public class SmartList<T>:List<T>
    {
       public int LastIndex {get; protected set;}   
    
       public new virtual void Add(T obj)
       {
          base.Add(obj);
          lastIndex = Count - 1;
       }
    
       public new virtual void AddRange(IEnumerable<T> obj)
       {
          base.AddRange(obj);
          lastIndex = Count - 1;
       }
    
       public new virtual void Insert(T obj, int index)
       {
          base.Insert(obj, index);
          lastIndex = index;
       }
    }
