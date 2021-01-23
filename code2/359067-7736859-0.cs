    static class GlobalDictionary
    {
      private static Dictionary<B,HashSet<A>> dictionary = new Dictionary<B,HashSet<A>>();
      
      public static HashSet<A> this[B obj]
      {
        // You could remove the set and have it check to see if a Set exists for a B
        // if not you would create it.
        get {return dictionary[obj];}
        set {dictionary[obj] = value;}
      }
    } 
      
    class A 
    {
      private B owner;  
      public B Owner
      {
        get{ return owner;}
        set
        {
          if (owner != null) GlobalDictionary[owner].Remove(this);
    
          owner = value;
          GlobalDictionary[owner].Add(this);
        }
      }
    }
    class B
    {
      public B()
      {
        GlobalDictionary[this] = new HashSet<A>();
      }
    
      public IEnumerable<A> Children
      {
        get
        {
          return GlobalDictionary[this];
        }
      }
    }
