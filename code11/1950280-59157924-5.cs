    //...
    var parameter = new Parameter(item.Id);
    
    IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    //simplified to recursive mock
    unitOfWork.Repositoty.GetItem(Arg.Is<Parameter>(p => p.Value == parameter.Value))
        .Returns(item);
    //...
