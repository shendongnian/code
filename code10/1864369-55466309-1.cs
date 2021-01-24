    //...
    static UnitTest1()
    {
        MockObject = new Mock<IMyClass>();
        var existingList = new List<DifferentClass>();
        MockObject
            .Setup(o => o.GetList())
            .ReturnsAsync(existingList);
    }
    //...
