      var mock = new Moq.Mock<IRepository>();
      mock.Setup(a => a.GetAll<int>(It.IsAny<Expression<Func<int, bool>>>(), It.IsAny<Func<IQueryable<int>, IOrderedQueryable<int>>>(), It.IsAny<Func<IQueryable<int>, IIncludableQueryable<int, object>>>(), It.IsAny<bool>()))
        .Returns<Expression<Func<int, bool>>, Func<IQueryable<int>, IOrderedQueryable<int>>, Func<IQueryable<int>, IIncludableQueryable<int, object>>, bool>((param1, param2, param3, param4) =>
        {
          return new[] { 1, 2, 3 }.AsQueryable();
        });
      var result = mock.Object.GetAll<int>();
