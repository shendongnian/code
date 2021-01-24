    using ( var context = new MyDbContext())
    {
        var tempClient = context.Clients.Single(x => x.Id == 1);
        var project = context.Projects.Single(x => x.Id == 1);
        Console.WriteLine("Has Client: " + (project.Client != null).ToString());
    }
