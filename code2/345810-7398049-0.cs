    public class AppCode : Application
    {
       // Entry point method
       [STAThread]
       public static void Main()
       {
          AppCode app = new AppCode();
          app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
          app.Run();
          ...
          app.Shutdown();
       }
    }
