    static class Program
    {
      /// <summary>
      /// </summary>
      static void Main()
      {
        if (!Environment.UserInteractive)
        {
          ServiceBase[] ServicesToRun;
          ServicesToRun = new ServiceBase[] 
              { 
                  new Service1() 
              };
          ServiceBase.Run(ServicesToRun);
        }
        else
        {
          Console.Write("Hit any key to continue...");
          Console.ReadKey();
        }
      }
    }
