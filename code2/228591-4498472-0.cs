    static class GroupExtensions
    {
       public static bool ContainsKey(this Groups groups, string key) 
       {
          try
          {
             if(groups[key] == null)
             {
                return false;
             }
          }
          catch
          {
             return false;
          }
          return true;
       }
    
    }
