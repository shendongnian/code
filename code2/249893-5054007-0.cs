    public static Mock<IRepository<T>> GetRepository<T>(params T[] items) where T: class {
        Mock<IRepository<T>> mock = new Mock<IRepository<T>>();
        mock.Setup(m => m.GetAll()).Returns(items.ToList().AsQueryable);
        return mock;
    }
