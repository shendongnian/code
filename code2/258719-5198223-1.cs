    public class Example
    {
      private static Dictionary<int, string> _list;
      public static void Invalidate()
      {
           _list = null;
      }
      public static Dictionary<int, string> GetExample()
      {
          if (_list == null)
              _list = new Dictionary<int, string>();
         return _list;
      }
    }
