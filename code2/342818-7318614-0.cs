        struct YourStruct
        {
           public int Id; 
        }
        
        class Comparer : IEqualityComparer<YourStruct>
        {
    
          public bool Equals(YourStruct a, YourStruct b)
          {
            return a.Id == b.Id;
          }
    
    
          public int GetHashCode(YourStruct s)
          {
            return s.Id;
          }
    
        }
            
        List<YourStruct> list = new List<YourStruct>();
        HashSet<YourStruct> hs = new HashSet<YourStruct>(list, new Comparer());
