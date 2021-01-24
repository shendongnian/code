    using (var context = new TestDbContext())
    {
        var test = context.Messages.Take(1000000).ToList();
        Assert.IsTrue(true);
    }
