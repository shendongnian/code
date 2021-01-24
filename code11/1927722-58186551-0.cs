    if (String.Equals(args[0], "myprog:Open", StringComparison.InvariantCultureIgnoreCase))
    {
         var program = args[1];
         List<string> commandLineArgs = new List<string>();
         for (int i = 2; i < args.Count(); i++)
         {
             commandLineArgs.Add(args[i]);
         }
    
          ProcessStartInfo startInfo = new ProcessStartInfo();
          startInfo.FileName = program;
          startInfo.Arguments = string.Join(" ", commandLineArgs);
          var process = Process.Start(startInfo);
     }
