        public static void PrintTargetRuntime()
        {
                var framework = Assembly
                        .GetEntryAssembly()?
                        .GetCustomAttribute<TargetFrameworkAttribute>()?
                        .FrameworkName;
        
                var stats = new
                {
                    	OsPlatform =          System.Runtime.InteropServices.RuntimeInformation.OSDescription,
                	AspDotnetVersion = framework
        	};
        }
