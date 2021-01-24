    static public class HashSetHelper
    {
      static public bool ContainsValues(this HashSet<List<int>> set, List<int> list)
      {
        if ( set.Count == 0 )
          return false;
        foreach ( var item in set )
        {
          if ( item.Count != list.Count )
            return false;
          for ( int index = 0; index < item.Count; index++ )
            if ( item[index] != list[index] )
              return false;
        }
        return true;
      }
    }
