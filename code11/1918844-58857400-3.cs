    [Test]
    public virtual async Task FromSqlThenFirstOrDefaultAsync_ReturnsFirstElement()
    {
        var storedProcedureReturns = Fixture.CreateMany<TestEntity>().ToList();
        var mockedDbContext = 
            Create.MockedDbContextFor(new TestDbContext(new DbContextOptionsBuilder<TestDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options));
        mockedDbContext.Set<TestEntity>().AddFromSqlResult("usp_SomeStoredProcedure", storedProcedureReturns);
    
        var actualResult = await mockedDbContext.Set<TestEntity>().FromSql("[dbo].[usp_SomeStoredProcedure] @Parameter1, @Parameter2").FirstOrDefaultAsync();
    
        Assert.That(actualResult, Is.EqualTo(storedProcedureReturns.First()));
    }
