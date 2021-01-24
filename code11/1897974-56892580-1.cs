            var debug = string.Empty;
            #if DEBUG
                debug = "Debug";
            #else
                debug = "Release";
            #endif
            var userNameVariable = System.Environment.GetEnvironmentVariable("USER");
            debug += $"[{userNameVariable}]";
            var path = System.IO.Path.Combine(env.ContentRootPath, "bin", debug);
            var builder = new ConfigurationBuilder()
                .SetBasePath(path) //env.ContentRootPath
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
