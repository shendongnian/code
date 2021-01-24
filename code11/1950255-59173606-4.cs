    [TestMethod]
    public void TestMethod1()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<MockDbContext>().As<IMyDbContext>().InstancePerLifetimeScope();
        builder.RegisterDecorator<ApplicationDbContextAuditDecorator, IMyDbContext>();
        builder.RegisterType<MockCurrentUser>().As<ICurrentUser>();
        var container = builder.Build();
        var context = container.Resolve<IMyDbContext>();
        context.Staff.Add(new Staff());
        context.SaveChanges();
        Assert.AreEqual("Mock", context.Staff.Local.Single().CreatedBy);
    }
