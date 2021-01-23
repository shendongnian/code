    // 1. create the container
    var container = new WindsorContainer();
    
    // 2. add all the facilities I need
    container.AddFacility<SomeFacility>();
    contianer.AddFacility<SomeOtherFacility>();
    
    // 3. install all the components
    container.Install(FromAssembly.This());
