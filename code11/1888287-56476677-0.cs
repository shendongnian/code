    //create the new resolver that will be used to replace the current one
    IDependencyResolver resolver = MockRepository.GenerateMock<IDependencyResolver>();
    //mock expected behavior
    var testdetails = MockRepository.GenerateMock<ITestDetails>();
    resolver.Stub(_ => _.GetService(typeof(ITestDetails))).Returns(testDetails);
