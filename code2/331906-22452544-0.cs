    public static void SetupIQueryable<TRepository, TEntity>(this Mock<TRepository> mock, IQueryable<TEntity> queryable)
       where TRepository : class, IQueryable<TEntity>
    {
        mock.Setup(r => r.GetEnumerator()).Returns(queryable.GetEnumerator());
        mock.Setup(r => r.Provider).Returns(queryable.Provider);
        mock.Setup(r => r.ElementType).Returns(queryable.ElementType);
        mock.Setup(r => r.Expression).Returns(queryable.Expression);
    }
