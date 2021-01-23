    class Settings {
      public static int Foo { 
        get { return (int)_map["Foo"]; }
        set { _map["Foo"] = value; }
      }
      public static string Bar {
        get { return (string)_map["Foo"]; }
        set { _map["Foo"] = value; }
      }
      // ...
      private static Dictionary<string, object> _map = 
        new Dictionary<string, object>();
    }
