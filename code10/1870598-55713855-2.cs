    // Production class sample
    class ProductionController
    {
      public ProductionController(IService1 service1, IService2 service2) { }
    
      public void ControllerMethod()
      {
        var service1Result = service1.Method();
        service2.Method(service1Result);
      }
    }
    
    // Test sample
    // arrange
    var expectedResult = new Service1Result();
    var service1 = Mock.Of<IService1>(x => x.Method() == expectedResult);
    var service2 = Mock.Of<IService2>(x => x.Method(It.Is<Service1Result>(y => y == expectedResult)));
    var controller = new ProductionController(service1, service2);
    
    // act
    controller.ControllerMethod();
    
    // assert
    Mock.Get(service1).Verify(x => x.Method(), Times.Once);
    Mock.Get(service2).Verify(x => x.Method(expectedResult), Times.Once);
