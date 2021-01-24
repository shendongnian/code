    public static T GetStuff<T>(string title)
    {
       T result = default;
    
       Console.Write($"{title}: ");
    
       while (Local(Console.ReadLine()))
          Console.WriteLine($"You had one job, {title}: ");
    
       return result;
    
       bool Local(string value)
       {
          try
          {
             result = (T)Convert.ChangeType(value, typeof(T));
    
             return true;
          }
          catch (Exception e)
          {
              // didnt work
          }
          
          return false;
       }
    }
