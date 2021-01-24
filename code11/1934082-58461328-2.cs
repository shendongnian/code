    [Fact]
    public void Example() {
        var realRepository = new RealRepository();
        var proxyRepository = Substitute.For<IRepository>();
        proxyRepository
            .When(repo => repo.InsertValueForEntity(Arg.Any<int>(), Arg.Any<ValueForEntity>()))
            .Do(callInfo => realRepository
                .InsertValueForEntity((int)callInfo.Args()[0], (ValueForEntity)callInfo.Args()[1]));
        proxyRepository
            .GetValueForEntity(Arg.Any<int>())
            .Returns(callInfo => realRepository
                .GetValueForEntity((int)callInfo.Args()[0]));
        var factory = new EntityFactory(proxyRepository);
        var entity = factory.CreateEntity(42 /* args */); 
        proxyRepository.Received().InsertValueForEntity(entity.Id, Arg.Any<ValueForEntity>());
        proxyRepository.Received().GetValueForEntity(Arg.Is(entity.Id));
        Assert.Equal(42, entity.Id);
    }
