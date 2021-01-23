    using (MyEntities context = new MyEntities())
    {
        var activities = from act in context.Activities
                         where act.ActTwittered == false
                         select new { act.ActID, act.ActTitle, act.Category,
                         act.ActDateTime, act.Location, act.ActTwittered };
        foreach (var activity in activities)
        {
            twitter.PostUpdate("...");
            // Create fake object with necessary primary key
            var act = new Activity()
            {
                ActID = activity.ActID,
                ActTwittered = false
            };
            // Attach to context -> act is in state "Unchanged"
            // but change-tracked now
            context.Activities.Attach(act);
            // Change a property -> act is in state "Modified" now
            act.ActTwittered = true;
        }
        // all act are sent to server with sql-update statements
        // only for the ActTwittered column
        context.SaveChanges();
    }
