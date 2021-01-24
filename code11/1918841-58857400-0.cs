    [Test]
    public virtual async Task FirstOrDefaultAsync_ReturnsFirstElement()
    {
        var itemsToAdd = Fixture.CreateMany<TestEntity>();
    
        var mockedDbContext = Create.MockedDbContextFor(
            new TestDbContext(new DbContextOptionsBuilder<TestDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options));
        mockedDbContext.Set<TestEntity>().AddRange(itemsToAdd);
        mockedDbContext.SaveChanges();
    
        var actualResult1 = await mockedDbContext.Set<TestEntity>().FirstOrDefaultAsync();
    
        Assert.That(actualResult1, Is.EqualTo(itemsToAdd.First()));
    }
