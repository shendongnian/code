        public static void PrintTargetRuntime()
        {
                var framework = Assembly
                        .GetEntryAssembly()?
                        .GetCustomAttribute<TargetFrameworkAttribute>()?
                        .FrameworkName;
        
                var stats = new
            {
                OsPlatform = System.Runtime.InteropServices.RuntimeInformation.OSDescription,
                OSArchitecture = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture,
                ProcesArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture,
                FrameworkDescription = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
                AspDotnetVersion = framework
            };
            Console.WriteLine("Framework version is " + framework);
            Console.WriteLine("OS Platform is : " + stats.OsPlatform );
            Console.WriteLine("OS Architecture is : " + stats.OSArchitecture);
            Console.WriteLine("Framework description is " + stats.FrameworkDescription);
            Console.WriteLine("ASPDotNetVersion is " + stats.AspDotnetVersion);
            if (stats.ProcesArchitecture == Architecture.Arm)
            {
                Console.WriteLine("ARM process.");
            }
            else if (stats.ProcesArchitecture == Architecture.Arm64)
            {
                Console.WriteLine("ARM64 process.");
            }
            else if (stats.ProcesArchitecture == Architecture.X64)
            {
                Console.WriteLine("X64 process.");
            }
            else if (stats.ProcesArchitecture == Architecture.X86)
            {
                Console.WriteLine("x86 process.");
            }
        }
