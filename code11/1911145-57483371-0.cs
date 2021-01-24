    using McMaster.Extensions.CommandLineUtils;
    using System;
    
    namespace ConsolUtilsTest
    {
        class Program
        {
            public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);
    
            [Argument(0, Description = "Configuration file")]
            [FileExists]
            public string ConfigurationFile { get; }
    
            [Argument(1, Description = "Comparison file 1")]
            [FileExists]
            public string ComparisonFile1 { get; }
    
            [Argument(2, Description = "Comparison File 2")]
            [FileExists]
            public string ComparisonFile2 { get; }
    
            private void OnExecute()
            {
                Console.WriteLine(ConfigurationFile);
                Console.WriteLine(ComparisonFile1);
                Console.WriteLine(ComparisonFile2);
            }
        }
    }
