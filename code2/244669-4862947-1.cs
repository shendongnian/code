    [Test]
    public void test()
    {
        Exception ex = new ArgumentNullException();
        Exception wrapped = (Exception)Activator.
            CreateInstance(ex.GetType(), "wrapped", ex);
        Type expectedType = typeof(ArgumentNullException);
        Assert.IsInstanceOf(expectedType, wrapped, "Is ArgumentNullException.");
        Assert.AreEqual(ex, wrapped.InnerException, "Exception is wrapped.");
    }
