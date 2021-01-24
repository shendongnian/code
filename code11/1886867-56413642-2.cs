      public static List<object> ToList(this ITuple tuple)
      {
        var result = new List<object>(tuple.Length);
        for (int i = 0; i < tuple.Length; i++)
        {
          result.Add(tuple[i]);
        }
        return result;
      }
    }
