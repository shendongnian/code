    List<Activity> activities;
    using (MyEntities context = new MyEntities()) {
      activities = (
        from act in context.Activities
        where act.ActTwittered == false
        select new Activity(act.ActID, act.ActTitle, act.Category, act.ActDateTime, act.Location)
      ).ToList();
    }
