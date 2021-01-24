    // Short-lived contexts for demonstration /w lazy loading implemented:
    using (var context = new TestDbContext()) // represents our long-lived, static context...
    {
        var child = context.Children.Single(x => x.ChildId == 2);
        Assert.AreEqual("Sean", child.Name);
        var parent = context.Parents.AsNoTracking().Single(x => x.ParentId == 1);
        using(var innerContext = new TestDbContext()) // a short-lived context somewhere in a call stack, or an external process modifying data...
        {
           var sean = innerContext.Children.Single(x => x.ChildId == 2);
           sean.Name = "Shawn";
           innerContext.SaveChanges();
        }
         
        Console.Writeline(child.Name);
        var parentsChild = parent.Children.Single(x => x.ChildId == 2); // Lazy load gets triggered here.
        Console.Writeline(parentsChild.Name); 
        Console.Writeline(child.Name);
    }
