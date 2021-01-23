    using(var context = new MyDbContext())
    {
        var activity = new Activity { Personnel = "Foo", LocationName = "MyName" };
        context.Activities.Add(activity);
        context.SaveChanges();
    }
