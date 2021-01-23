    using System;
    namespace Example
    {
        public sealed class BuildControl
        {
            // ...
            public bool BuildStuff()
            {
                MsBuilder builder = new MsBuilder(@"C:\...\project.csproj", "Release", "x86")
                {
                    Target = "Rebuild", // for rebuilding instead of just building
                };
                bool success = builder.Build(out string buildOutput);
                Console.WriteLine(buildOutput);
                return success;
            }
            // ...
        }
    }
