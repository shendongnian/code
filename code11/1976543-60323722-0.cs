        string WorkItemTitle = "New API used for bulk import";
        Dictionary<string, object> fields = new Dictionary<string, object>();
        fields.Add("System.Title", WorkItemTitle);
        fields.Add("System.Description", $"Automatically created at {DateTime.Now}.");
        fields.Add("Microsoft.VSTS.Common.Priority", 4);
        fields.Add("System.AssignedTo", "Some Person");
