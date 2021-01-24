    var issue = jira.Issues.Queryable.FirstOrDefault(x => x.Key == "123");
    var ca = issue.CustomFields.First(x => x.Name == "My Cascade Field");
    string[] n = { "Existing Parent Value", "New Child Value" };
    ca.Values = n;
    
    issue.SaveChanges();
