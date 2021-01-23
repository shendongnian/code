    using(var session = Quickbooks.CreateSession())
    {
        // Check if the job already exist
        using (var message = session.CreateMessage())
        {
            var jobQuery = message.AppendCustomerQueryRq();
            jobQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameFilter.Name.SetValue("something");
            jobQuery.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
            var result = message.Send();
            // do stuff here with the result
        }
    }
