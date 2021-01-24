     if (args[0].StartsWith("myProg:Open",true, CultureInfo.CurrentCulture))
     {
         var split = args[0].Split(';');
         var argsString = split[1];
         var progArgs = argsString.Split('~');
          var program = progArgs[0];
          List<string> commandLineArgs = new List<string>();
          for (int i = 1; i < progArgs.Count(); i++)
          {
              commandLineArgs.Add(progArgs[i]);
          }
          ProcessStartInfo startInfo = new ProcessStartInfo();
          startInfo.FileName = program;
          startInfo.Arguments = string.Join(" ", commandLineArgs);
          var process = Process.Start(startInfo);
          return;
