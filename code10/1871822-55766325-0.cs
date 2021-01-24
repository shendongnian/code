    using System;
    using System.IO;
    using System.Linq;
    using EnvDTE;
    using EnvDTE80;
    class Program
    {
        static void Main(string[] args)
        {
            // VS2019
            var dteType = Type.GetTypeFromProgID("VisualStudio.DTE.16.0", true);
            var dte = (EnvDTE.DTE)System.Activator.CreateInstance(dteType);
            var sln = (SolutionClass)dte.Solution;
            // Solution to add projects to
            sln.Open(@"C:\Projects\MyProject\MySolution.sln");
            // Projects should be added to the "lib" solution-folder.
            var lib = FindSolutionFolderOrCreate(sln, "lib");
            // These projects should be added.
            var projectPaths = new[]
            {
                @"C:\Projects\MyLibs\Lib1.csproj",
                @"C:\Projects\MyLibs\Lib2.csproj"
            };
            foreach (var path in projectPaths)
            {
                var name = Path.GetFileNameWithoutExtension(path);
                // If project not already in the solution-folder then add it.
                if(!(lib.Parent.ProjectItems.Cast<ProjectItem>().Any(pi => pi.Name == name)))
                {
                    lib.AddFromFile(path);
                }
            }
            dte.Solution.Close(true);
        }
        private static SolutionFolder FindSolutionFolderOrCreate(SolutionClass sln, string folderName)
        {
            foreach (var x in sln.Projects)
            {
                if (x is Project p && p.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase))
                {
                    return (SolutionFolder)p.Object;
                }
            }
            var proj = (sln as Solution2).AddSolutionFolder(folderName);
            return (SolutionFolder)proj.Object;
        }
    }
