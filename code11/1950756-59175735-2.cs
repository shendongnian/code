    IServiceCollection services = new ServiceCollection();
    //mocking service
    var mock = Mock.Of<IFileStorage>(_ => 
        _.GetShortTemporaryLink(It.IsAny<string>()) == "fake link"
    );
    //adding mock to service collection.
    services.AddTransient<IFileStorage>(sp => mock);
    
    //adding auto mapper with desired profile;
    services.AddAutoMapper(typeof(MappingProfile));
    
    //...add other dependencies as needed to service collection.
    
    //...
    
    //build provider
    IServiceProvider serviceProvider = service.BuilderServiceProvider();
    
    //resolve mapper
    IMapper mapperStub = serviceProvider.GetService<IMapper>();
    //Or resolve subject under test where mapper is to be injected
    SubjectClass subject = serviceProvider.GetService<SubjectClass>();
    //assuming ctr: public SubjectClass(IMapper mapper, .....) { ... }
