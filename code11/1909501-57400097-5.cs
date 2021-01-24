    [Test]
    public void Test()
    {
        // Arrange
        string categoryId = "categoryId";
        IService service = A.Fake<IService>();
        ClassToTest sut = new ClassToTest(service);
        // Act
        sut.GetProducts(categoryId);
        // Assert
        A.CallTo(() => service.Get(A<Category>.That.Matches(i => i.id == categoryId && i.flag)))
         .MustHaveHappened();
    }
