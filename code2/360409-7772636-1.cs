    // Arrange the test objects
    var viewResolverMock = MockRepository.GenerateMock<IViewResolver>();
    viewResolverMock.Stub(x => x. GetViewFor(thisTestViewName).Return(thisTestView);
    var myViewModel = new MyViewModel(viewResolverMock);
    
    // Do the actual operation on your tested object (the view model)
    var actualResult = myViewModel.DoSomethingWithTheView();
    // Assert 
    AssertAreEqual(expectedResult, actualResult);
