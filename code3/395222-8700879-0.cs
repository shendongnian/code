    // Replace
    var mock = MockRepository.GenerateStub<IMyInterface>();
    // with
    var mock = MockRepository.GenerateMock<IMyInterface>();
    // and everything should work as expected.
