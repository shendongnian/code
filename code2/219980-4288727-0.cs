    public RepositoryTest()
    {
        IQueryable<MockObjectSet> mocks = new List<MockObjectSet>()
        {
            new MockObjectSet { FirstName = "Beta", LastName = "Alpha", Mobile = 12345678 },
            new MockObjectSet { FirstName = "Alpha", LastName = "Beta", Mobile = 87654321 }
        }.AsQueryable();
    
        var mockRepository = new Mock<IRepository<MockObjectSet>>();
    
        mockRepository.Setup(x => x.GetBy(It.IsAny<Expression<Func<MockObjectSet, bool>>>()))
            .Returns<Expression<Func<MockObjectSet, bool>>>(predicate => mocks.Where(predicate).ToList());
    
    }
