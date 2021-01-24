        // Set up to run as a service if not in Debug mode or if a command line argument is not --console
        var isService = !(Debugger.IsAttached || args.Contains("--console"));
        if (isService)
        {
            var processModule = Process.GetCurrentProcess().MainModule;
            if (processModule != null)
            {
                var pathToExe = processModule.FileName;
                var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                Directory.SetCurrentDirectory(pathToContentRoot);
            }
        }
        ConfigureSerilog();
