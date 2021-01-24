    public static void WriteDate()
     {
      // Create the scope, resolve your IDateWriter,
      // use it, then dispose of the scope.
      using (var scope = Container.BeginLifetimeScope())
      {
        var writer = scope.ResolveNamed<IDateWriter>("console"); // for console output
        //var writer = scope.ResolveNamed<IDateWriter>("logs"); // for logs output
        writer.WriteDate();
      }
    }
