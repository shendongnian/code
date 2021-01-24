csharp
private IServiceProvider BuildServiceProvider()
{
    var services = new ServiceCollection();
    services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"), 
        ServiceLifetime.Scoped, 
        ServiceLifetime.Scoped);
    return services.BuildServiceProvider();
}
Then use this function to build the provider in each test
[TestMethod]
public void TestMethod1()
{
    using (var serviceProvider = BuildServiceProvider()) 
    {
        using (var dbContext = serviceProvider.GetService<AppDbContext>())
        {
            dbContext.Person.Add(new Person { Id = 0, Name = "test1" });
            dbContext.SaveChanges();
            Assert.IsTrue(dbContext.Person.Count() == 1);
        }
    }
}
This might cause the execution time to be a little bit higher than before but should definitely prevent your current problem from happening again. 
Tip:
You could also use the c# 8 syntax using statements now since you are running on `netcoreapp3.1`
c#
[TestMethod]
public void TestMethod1()
{
    using var serviceProvider = BuildServiceProvider();
    
    using var dbContext = ServiceProvider.GetService<AppDbContext>();
    dbContext.Person.Add(new Person { Id = 0, Name = "test1" });
    dbContext.SaveChanges();
    
    Assert.IsTrue(dbContext.Person.Count() == 1);
}
