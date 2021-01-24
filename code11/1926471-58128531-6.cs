    public static void GetStuff<T>(string title, Action<T> action)
    {
       Console.Write($"{title}: ");
    
       while (Local(Console.ReadLine()))
          Console.Write($"You had one job, {title}: ");
    
       bool Local(string value)
       {
          try
          {
             action((T)Convert.ChangeType(value, typeof(T)));
    
             return true;
          }
          catch (Exception e)
          {
             Console.Write($"You had one job, {title}: ");
          }
    
          return false;
       }
    }
