	1) initiate jira client:
        var jiraClient = Jira.CreateRestClient(<jiraURL>, <jiraUserName>, <jiraUserPwd>);
		
	2) connect to jira, and pull based on search criteria:
	
         var jql =  "project = QA + " AND status in (To Do)";
        IEnumerable<Atlassian.Jira.Issue> jiraIssues = AsyncTasker.GetIssuesFromJQL(jiraClient, jql, 999);
	3) then, you can enumerate in the pulled issues
        ...
        foreach(var issue in jiraIssues)
        {	
			/*		
			... for example, some of the available attributes are:
						
						issue.Key.Value
						issue.Summary
						issue.Description
						issue.Updated
						String.Format("{0}/browse/{1}", jiraURL.TrimEnd('/') , issue.Key.Value)
			...
			*/
		}                    
