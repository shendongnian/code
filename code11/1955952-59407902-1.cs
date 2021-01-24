     static void Main(string[] args)
     {
        string historyField = "System.History";
        string changedDateField = "System.ChangedDate";
        string changedByField = "System.ChangedBy";
        WorkItemStore store = new WorkItemStore("<your_server_url>/tfs/DefaultCollection");
        WorkItem wi = store.GetWorkItem(your_id);
        foreach (Revision rev in wi.Revisions)
        {
            if (rev.Fields[historyField].Value.ToString() != "")
            {
                Console.WriteLine("{0}: {1} says: \n{2}",
                    rev.Fields[changedDateField].Value,
                    rev.Fields[changedByField].Value,
                    rev.Fields[historyField].Value);
            }
        }
    }
