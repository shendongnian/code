            string path= string.Empty;
            var solutionFile =SolutionFile.Parse(@"D:\test.sln");// Your solution place.
            var projectsInSolution = solutionFile.ProjectsInOrder;
            foreach (var project in projectsInSolution)
            {
               if(project.ProjectName=="TestDLL")     //your  dll name
                {
                    path = project.AbsolutePath;
                    DirectoryInfo di = new DirectoryInfo(string.Format(@"{0}..\..\", path));
                    path = di.FullName;
                    foreach (var item in Directory.GetFiles(path,"*.json")) // filter the josn file in the correct path
                    {
                        if(item.StartsWith("Sample"))
                        {
                            Console.WriteLine(item);// you will get the correct json file path
                        }
                    }
                }
            }
