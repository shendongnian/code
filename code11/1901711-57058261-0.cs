    static void GetQueryClientAPI()
            {
                VssCredentials Credentials = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "Personal access token"));
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri("devops url"), Credentials);
                tpc.EnsureAuthenticated();
                WorkItemStore wis = tpc.GetService(typeof(WorkItemStore)) as WorkItemStore;
                QueryHierarchy qh = wis.Projects["project name"].QueryHierarchy;
                foreach(QueryItem q in qh)
                {
                    GetChildQuery(q);
                }
                Console.Read();
            }
            static void GetChildQuery(QueryItem query)
            {
    
                if (query is QueryFolder)
                {
                    QueryFolder queryFolder = query as QueryFolder;
                    foreach (var q in queryFolder)
                    {
                        GetChildQuery(q);
                    }
                }
                else
                {
                    QueryDefinition querydef = query as QueryDefinition;
                    Console.WriteLine(querydef.Name + " -- " + querydef.Path);
                }
            }
