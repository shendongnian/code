    public static AutoResetEvent manualReset;
    // Host the service within this EXE console application.
    public static void Main()
    {
      manualReset = new AutoResetEvent(false);
      ThreadPool.QueueUserWorkItem(AttachService);
      //Prevent thread from exiting
      manualReset.WaitOne(); //wait for a signal to exit
    }
    static void AttachService(Object stateInfo)
    {
      // Create a ServiceHost for the CalculatorService type.
      using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), new Uri("net.tcp://localhost:9000/servicemodelsamples/service")))
      {
        // Open the ServiceHost to create listeners and start listening for messages.
        serviceHost.Open();
        // The service can now be accessed.
        //put example Set() signal in your logic to stop the service when needed
        //manualReset.Set();
      }
    }
