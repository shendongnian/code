    string queryWiqlList = @"SELECT [System.Id] FROM WorkItems WHERE [System.TeamProject] = 'TEAM_PROJECT_NAME' and [System.Title] Contains '<YOUR SEARCH_TEXT>' and [System.State] <> 'Removed' and [System.State] <> 'Closed'";
    
    Wiql wiql = new Wiql();
    wiql.Query = wiqlStr;
    WorkItemQueryResult result = WitClient.QueryByWiqlAsync(wiql).Result;
    
    if (result != null)
    {
        if (result.WorkItems != null) // this is Flat List 
            foreach (var wiRef in result.WorkItems)
            {
                var wi = WitClient.GetWorkItemAsync(wiRef.Id).Result;
                Console.WriteLine(String.Format("{0} - {1}", wi.Id, wi.Fields["System.Title"].ToString()));
            }
    }
