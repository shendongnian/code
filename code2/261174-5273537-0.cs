            TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("http://tfs:8080"));
            var vcs = tfs.GetService<VersionControlServer>();
            var teamProjects = vcs.GetAllTeamProjects(true);
            IBuildServer buildServer = (IBuildServer)tfs.GetService(typeof(IBuildServer));
            foreach (TeamProject proj in teamProjects)
            {
                var builds = buildServer.QueryBuilds(proj.Name);
                foreach (IBuildDetail build in builds)
                {
                    var result = string.Format("Build {0}/{3} {4} - current status {1} - as of {2}",
                        build.BuildDefinition.Name,
                        build.Status.ToString(),
                        build.FinishTime,
                        build.LabelName,
                        Environment.NewLine);
                    System.Console.WriteLine(result);
                }
                
            }
