    public T Build()
    {
        if (typeof(T).IsInterface)
        {
           return new Mock<T>(MockBehavior.Strict).Object;
        }
    }
