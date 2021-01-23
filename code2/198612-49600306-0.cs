    var solutionFile =    
    SolutionFile.Parse(@"c:\NuGetApp1\NuGetApp1.sln");//your solution full path name
    var projectsInSolution = solutionFile.ProjectsInOrder;
    foreach(var project in projectsInSolution)
    {
       switch (project.ProjectType)
       {
          case SolutionProjectType.KnownToBeMSBuildFormat:
         {
             break;
         }
         case SolutionProjectType.SolutionFolder:
         {
             break;
         }
      }
    }
