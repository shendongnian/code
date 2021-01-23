    using (var context = new LDC_Entities())
    {
        context.Job.MergeOption = MergeOption.NoTracking;
        return context.Clients.Include("Registered_Office")
            .Where(c => c.Registered_Office_ID == officeID)
            .ToList();
    }
