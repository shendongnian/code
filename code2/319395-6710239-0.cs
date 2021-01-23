    public struct Exclusive<T>
    {
       public Exclusive(T item)
       {
         if (c.GetType () != typeof(ParentKey))
           throw new Exception (); // I want compiler error here!
         Item = item;
       }
       public T Item{get; private set;}
       // todo: add implicit cast to T
       // todo: add forcing non-null to get_Item
    }
