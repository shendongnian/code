    public class Program
    {
      static public Dictionary<string, Tuple<object, object>> GetChangedProperties<T>(T a, T b) where T : class
      {
        if ( a != null && b != null )
        {
          if ( Object.Equals(a, b) )
          {
            return new Dictionary<string, Tuple<object, object>>();
          }
          var allProperties = a.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
          var result = new Dictionary<string, Tuple<object, object>>();
          foreach ( var p in allProperties )
          {
            var v1 = p.GetValue(a);
            var v2 = p.GetValue(b);
            if ( !Object.Equals(v1, v2) )
              result.Add(p.Name, new Tuple<object, object>(v1, v2));
          }
          return result;
        }
        else
        {
          var aText = $"{( a == null ? ( "\"" + nameof(a) + "\"" + " was null" ) : "" )}";
          var bText = $"{( b == null ? ( "\"" + nameof(b) + "\"" + " was null" ) : "" )}";
          var bothNull = !string.IsNullOrEmpty(aText) && !string.IsNullOrEmpty(bText);
          throw new ArgumentNullException(aText + ( bothNull ? ", " : "" ) + bText);
        }
      }
      public class Test
      {
        public int A { get; set; }
        public int B { get; set; }
      }
      static void Main(string[] args)
      {
        var v1 = new Test { A = 10, B = 20 };
        var v2 = new Test { A = 5, B = 20 };
        var list = GetChangedProperties(v1, v2);
        foreach ( var item in list )
          Console.WriteLine($"{item.Key}: {item.Value.Item1.ToString()} != {item.Value.Item2.ToString()}");
        Console.ReadKey();
      }
    }
