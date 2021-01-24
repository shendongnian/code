    using ( var context = new MyDbContext())
    {
        var project = context.Projects.Single(x => x.Id == 1);
        Console.WriteLine("Has Client: " + (project.Client != null).ToString());
    }
