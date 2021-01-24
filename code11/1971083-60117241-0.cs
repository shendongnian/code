    using System;
    using System.IO;
    using System.Diagnostics;
    
    namespace Test
    {
        class Program
        {
            public static string AssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            public static string  AssemblyParentPath = Path.GetDirectoryName(AssemblyPath);
    
            static void Main(string[] args)
            {
                Console.WriteLine("Opening PDF");
                var artPath = GetArtifactPath("test.pdf");
                Process.Start(artPath);
                Console.Read();
            }
            private static string GetArtifactPath(string artifactName)
            {
                return Path.Combine(GetResourcePath(), artifactName);
            }
    
            private static string GetResourcePath()
            {
                return Path.Combine(AssemblyParentPath, "Resources","Guidelines");
            }
    
        }
    }
