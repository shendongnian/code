    using (var context = new TestDbContext())
    {
        var test = context.Messages.ToList();
        Assert.IsTrue(true);
    }
