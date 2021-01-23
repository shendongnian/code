    static void Main(string[] args)
    {
      var service = new Service(); //this is your generated web service class
      var method = service.GetType().GetMethod(args[0]); //gets the method from the command line
      // create an array to hold the other arguments
      var myArgs = new Object[args.Length-1];
      for(int i=0; i<myArgs.Length; ++i)
      {
        myArgs[i] = args[i+1];
      }
      method.Invoke(service, myArgs);
    }
