    using System;
    using System.ServiceModel;
    
    class Program
    {
      static String TITLE_TEXT = "MyService -- Console Host ({0})" + (System.Diagnostics.Debugger.IsAttached?" [DEBUG]":"");
      static void Main(string[] args)
      {
        Console.Title = String.Format(TITLE_TEXT, "Not Running");
        try
        {
          ServiceHost host = new ServiceHost(typeof(MyService));
    
          Console.Title = String.Format(TITLE_TEXT, "Starting");
          host.open();
    
          Console.Title = String.Format(TITLE_TEXT, "Running");
          Console.WriteLine("Service is started, press any key to exit.");
          Console.ReadKey();
    
          Console.Title = String.Format(TITLE_TEXT, "Closing");
          host.close();
          host = null;
          Console.Title = String.Format(TITLE_TEXT, "Closed");
        }
        catch (Exception ex)
        {
          Console.Title = String.Format(TITLE_TEXT, "Exception");
          Console.WriteLine("An error occured while running the host:");
          Console.WriteLine(ex.Message);
          Console.WriteLine();
          Console.WriteLine(ex.StackTrace);
          Console.ReadLine();
        }
      }
    }
