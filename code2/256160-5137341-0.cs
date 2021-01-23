    public static class RepositoryHelpers<T> where T : class
    {
        public static Mock<IRepository<T>> GetMockRepository<T>(params T[] items) 
        {
            Mock<IRepository<T>> mock = new Mock<IRepository<T>>();
            mock.Setup(m => m.GetAll()).Returns(items.AsQueryable());
            return mock;
        }
    }
