    public static IEnumerable<T> EveryOther(this IEnumerable<T> list)
    {
       bool send = true;
       foreach(var item in list)
       {
          if (send) yield return item;
          send = !send;
       }
    }
