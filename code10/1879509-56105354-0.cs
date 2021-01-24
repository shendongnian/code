     var projectPath = @"C:\Users\hamza\Desktop\TestSolution\TestSolution.sln";
            using (var workspace = MSBuildWorkspace.Create())
            {
                var solution = workspace.OpenSolutionAsync(projectPath).Result;
                foreach (var project in solution.Projects)
                {
                    foreach (var document in project.Documents)
                    {
                        Console.WriteLine(project.Name + "\t\t\t" + document.Name);
                    }
                }
            }
