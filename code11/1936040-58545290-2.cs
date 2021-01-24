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
                Console.WriteLine("Framework version is " + framework);
                Console.WriteLine("OS Platform is : " + stats.OsPlatform );
                Console.WriteLine("ASPDotNetVersion is " + stats.AspDotnetVersion);
        }
