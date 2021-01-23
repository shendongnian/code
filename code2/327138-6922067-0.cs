    [Test]
    public void Some_Action_In_SomeController_Should_Do_Something()
    {
        var service1Mock = new Mock<IService1>();
        var service2Mock = new Mock<IService2>();
        var controller = new SomeController(service1Mock.Object, service2Mock.Object);
    
        controller.Action();
    
        // Assert stuff
    }
