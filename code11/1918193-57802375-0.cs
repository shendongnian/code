            string _uri = "https://dev.azure.com/nareshkumar0275";
            string _personalAccessToken = 
           "37bsxpdrix7nyspotj3l4gotvvk4cpp2z6l65g5rd4pfbrl7nskq";
            string _project = "FirstProject";
            /// <summary>
            /// Execute a WIQL query to reutnr a list of bugs using the .NET client library
            /// </summary>
            /// <returns>List of Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem</returns>
            Uri uri = new Uri(_uri);
            string personalAccessToken = _personalAccessToken;
            string project = _project;
            VssBasicCredential credentials = new VssBasicCredential("", _personalAccessToken);
            //create a wiql object and build our query
            Wiql wiql = new Wiql()
            {
                Query = "Select *" +
                        "From WorkItems " +
                        
                        "Where [System.TeamProject] = '" + project + "' " +
                       
                        "Order By [State] Asc, [Changed Date] Desc"
            };
            //create instance of work item tracking http client
            using (WorkItemTrackingHttpClient workItemTrackingHttpClient = new WorkItemTrackingHttpClient(uri, credentials))
            {
                //execute the query to get the list of work items in teh results
                WorkItemQueryResult workItemQueryResult = workItemTrackingHttpClient.QueryByWiqlAsync(wiql).Result;
                //some error handling                
                if (workItemQueryResult.WorkItems.Count() != 0)
                {
                    //need to get the list of our work item id's and put them into an array
                    List<int> list = new List<int>();
                    foreach (var item in workItemQueryResult.WorkItems)
                    {
                        list.Add(item.Id);
                    }
                    int[] arr = list.ToArray();
                
                    
                    
                    //get work items for the id's found in query
                    var workItems = workItemTrackingHttpClient.GetWorkItemsAsync(arr).Result;
                    Console.WriteLine("Query Results: {0} items found", workItems.Count);
                    //loop though work items and write to console
                    foreach (var workItem in workItems)
                    {
                        Console.WriteLine("{0}          {1}                     {2}", workItem.Id, workItem.Fields["System.Title"], workItem.Fields["System.AssignedTo"]);
                    }
                }
            }
            Console.ReadLine();
        }
