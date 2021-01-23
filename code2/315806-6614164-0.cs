    using(var context = new MyDbContext())
    {
        var location = new Location { Name = "MyName" };
        context.Locations.Attach(location);
        var activity = new Activity { Personnel = "Foo", Location = location };
        context.Activities.Add(activity);
        context.SaveChanges();
    }
