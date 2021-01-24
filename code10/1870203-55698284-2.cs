    using (var context = new SomethingDbContext())
    {
        context.ShouldIntercept = true;
        var test = context.Somethings.Any(); // Triggers schema check/creation.
    }
