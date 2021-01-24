    [Test]
    public void Test()
    {
        // Arrange
        string actualId = null;
        bool? actualFlag = null;
        string categoryId = "categoryId";
        IService service = A.Fake<IService>();
        A.CallTo(() => service.Get(A<Category>.Ignored)).Invokes((Category category) =>
          {
              actualId = category.id;
              actualFlag = category.flag;
          });
        ClassToTest sut = new ClassToTest(service);
        // Act
        sut.GetProducts(categoryId);
        // Assert
        Assert.AreEqual(categoryId, actualId);
        Assert.AreEqual(true, actualFlag);
        // optionaly, because it obviously happened
        A.CallTo(() => service.Get(A<Category>.Ignored))
                              .MustHaveHappened();
    }
