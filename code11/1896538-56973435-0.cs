    var service = connection.CreateIssuesService();
    var newIssue = new Issue
    {
        Summary = "Test issue",
        Description = "Test issue description."
    };
    newIssue.SetField("Assignee", "root");
    newIssue.SetField("Type", "Bug"); // non default value
    newIssue.SetField("Due Date", DateTime.UtcNow.AddDays(5));
    var result = service.CreateIssue("SP", newIssue).Result;
