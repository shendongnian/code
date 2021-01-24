    var mock = Mock.Create<IYourInterface>(); 
    string expectedResult = "result"; 
    Mock.Arrange(() => mock.TryProcessRequest(out expectedResult)).Returns(true); 
    string actualResult; 
    bool isCallSuccessful = mock.TryProcessRequest(out actualResult);
