    public class Program
    {
      static public List<string> GetChangedProperties<T>(T a, T b) where T : class
      {
        if ( a != null && b != null )
        {
          if ( Object.Equals(a, b) )
          {
            return new List<string>();
          }
          var allProperties = a.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
          return allProperties.Where(p => !Object.Equals(p.GetValue(a), p.GetValue(b)))
                              .Select(p => p.Name).ToList();
        }
        else
        {
          var aText = $"{( a == null ? ( "\"" + nameof(a) + "\"" + " was null" ) : "" )}";
          var bText = $"{( b == null ? ( "\"" + nameof(b) + "\"" + " was null" ) : "" )}";
          var bothNull = !string.IsNullOrEmpty(aText) && !string.IsNullOrEmpty(bText);
          throw new ArgumentNullException(aText + ( bothNull ? ", " : "" ) + bText);
        }
      }
      public class A
      {
        public int a { get; set; }
        public int b { get; set; }
      }
      static void Main(string[] args)
      {
        var v1 = new A { a = 10, b = 20 };
        var v2 = new A { a = 5, b = 20 };
        var list = GetChangedProperties(v1, v2);
        foreach (string item in list)
          Console.WriteLine(item);
        Console.ReadKey();
      }
    }
