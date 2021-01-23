    // Holds the Log4Net logger.
    private static readonly Logger _Log = Logger.GetLogger(typeof(Program));
    internal static void Main(string[] args)
      {
         Environment.ExitCode = 0;
         var result = false;
         try
         {
            _Log.Debug(new string('=', 80));
            _Log.Debug("Starting");
            _Log.Debug("Location: {0}", Assembly.GetExecutingAssembly().Location);
            if (args.Length != 5)
            {
               throw new InvalidOperationException("Invalid number of arguments");
            }
            if (args[0] != "/install" && args[0] != "/uninstall")
            {
               throw new InvalidOperationException("First argument should be \"/install\" or \"/uninstall\"");
            }
            if (args[0] == "/install")
            {
               _Log.Debug("Installing...");
               _Log.Debug("DO NOTHING, BUT START AND STOP!!!");
               result = true;
               _Log.Debug("Installed: Result={0}", result);
            }
            else if (args[0] == "/uninstall")
            {
               _Log.Debug("Uninstalling...");
               _Log.Debug("DO NOTHING, BUT START AND STOP!!!");
            }
         }
         catch (Exception e)
         {
            _Log.Error("ERROR: " + e.Message + "\r\n" + e.StackTrace);
            Environment.ExitCode = -1;
         }
         finally
         {
            _Log.Debug("Stopping...");
            if (result)
            {
               _Log.Debug("Setting ExitCode to 0.");
               Environment.ExitCode = 0;
            }
            else
            {
               _Log.Debug("Setting ExitCode to -1.");
               Environment.ExitCode = -1;
            }
         }
         _Log.Dispose();
         GC.Collect();
         GC.WaitForPendingFinalizers();
         _Log.Debug("Exiting with exitcode: {0}", Environment.ExitCode);
         Environment.Exit(Environment.ExitCode);
      }
