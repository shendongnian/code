     var domain  = AppDomain.CurrentDomain;
     domain.UnhandledException += (o, args) =>
                                             {
                                                 Debug.WriteLine("Catched in UnhandledException");
                                                 Debug.WriteLine(args.ExceptionObject);
                                             };
    
      domain.FirstChanceException += (o, args) =>
                                               {
                                                   Debug.WriteLine("Catched in FirstChanceException");
                                                   Debug.WriteLine(args.Exception);
                                               };
    
    TaskScheduler.UnobservedTaskException += (o, args) =>
                                                         {
                                                             Debug.WriteLine("Catched in UnobservedTaskException");
                                                             Debug.WriteLine(args.Exception);
                                                         };
    Task.Factory.StartNew(async () =>
                                      {
                                          Debug.WriteLine("Workinf");
                                          await Task.Delay(1000);
                                          try
                                          {
                                              throw new Exception("oops");
                                          }
                                          catch (Exception exception)
                                          {
    
                                              throw new Exception("oopps catched", exception);
                                          }
                                      });   
