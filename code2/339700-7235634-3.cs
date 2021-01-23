    public static void AtATime<T>(this IEnumerable<T> list, int eachTime, Action<IEnumerable<T>> action)
    {
          var taken = 0;
          while(list.Count() >= taken)
          {
               action(list.Skip(taken).Take(eachTime));
               taken += eachTime;    
          }
    }
