    public class Application
    {
      private static string _rootPath = HttpContext.Current.Server.MapPath("~");
      public static string RootPath
      {
          get { return _rootPath; }
      }
    }
