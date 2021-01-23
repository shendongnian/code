      public class Foo
      {
        private static void Bar(string key = "undefined key", string value = "undefined value")
        {
          Console.WriteLine(string.Format("The key is '{0}'", key));
          Console.WriteLine(string.Format("The value is '{0}'", value));
        }
      }
