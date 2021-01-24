    //Prompt user for credential
                VssConnection connection = new VssConnection(new Uri(azureDevOpsOrganizationUrl), new VssClientCredentials());
    
                //create http client and query for resutls
                WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
                Wiql query = new Wiql() { Query = "SELECT [Id], [Title], [State] FROM workitems WHERE [Work Item Type] = 'Bug' AND [Assigned To] = @Me" };
                WorkItemQueryResult queryResults = witClient.QueryByWiqlAsync(query).Result;
    
                //Display reults in console
                if (queryResults == null || queryResults.WorkItems.Count() == 0)
                {
                    Console.WriteLine("Query did not find any results");
                }
                else
                {
                    foreach (var item in queryResults.WorkItems)
                    {
                        Console.WriteLine(item.Id);
                    }
                }
