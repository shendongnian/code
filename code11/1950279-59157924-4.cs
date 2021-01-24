    public void Test() {
        var id = 22
        Item item = new Item();
        item.Id = id;
    
        var parameter = new Parameter(item.Id);
    
        IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
        //simplified to recursive mock
        unitOfWork.Repositoty.GetItem(Arg.Any<Parameter>()).Returns(item);
    
        IService service1 = new Service1(unitOfWork);
        IService service2 = new Service2(unitOfWork);
    
        //Act
        var result1 = service1.GetResult(id);
        var result2 = service2.GetResult(parameter);    
        //Assert
        Assert.That(result1.Id == item.Id);
        Assert.That(result2.Id == item.Id);
    }
