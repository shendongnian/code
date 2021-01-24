    using System;
    using Microsoft.Build.Evaluation;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                var projectCollection = new ProjectCollection();
                var projFile          = @"E:\Test\CS7\ConsoleApp1\ConsoleApp1.csproj";
                var project           = projectCollection.LoadProject(projFile);
                var projectReferences = project.GetItems("ProjectReference");
                foreach (var projectReference in projectReferences)
                {
                    Console.WriteLine(projectReference.EvaluatedInclude);
                }
            }
        }
    }
