    [Test]
    public void TestThatLogicABCWorks()
    {
        Mock<IRepositoryA> mockInstance1 = new Mock<IRepositoryA>();
        mockInstance1.Setup(foo => foo.Do()).Returns(() => 1);
        Mock<IRepositoryB> mockInstance2 = new Mock<IRepositoryB>();
        mockInstance2.Setup(boo => boo.Do2()).Returns(() => 2);
        Mock<IRepositoryC> mockInstance3 = new Mock<IRepositoryC>();
        mockInstance3.Setup(doo => doo.Do3()).Returns(() => 3);
        LogicABC logic = new LogicABC(mockInstance1.Object, mockInstance2.Object, mockInstance3.Object);
        logic.DoLogic();
        // do some asserts here
    }
