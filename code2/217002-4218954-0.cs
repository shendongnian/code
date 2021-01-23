    public static Dictionary<dynamic, int> Count(dynamic[] array) 
      {
       
       Dictionary<dynamic, int> counts = new Dictionary<dynamic, int>();
       
       foreach(var item in array) {
        
        if (!counts.ContainsKey(item)) {
         counts.Add(item, 1);
        } else {
         counts[item]++;
        }
        
        
       }
       
      return counts;    
      }
