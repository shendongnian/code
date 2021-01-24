    class Program {
      public static void Main(string[] args) {
          var dll = Assembly.LoadFile(@"my dll");
          foreach(Type type in dll.GetExportedTypes())
          {
              dynamic c = Activator.CreateInstance(type);
              c.MyCallback = Print;
              c.Bar(@"Hello");
          }
          Console.ReadLine();
      }
      public static void Print(string s) {
          Console.WriteLine(s);
      }
    }
