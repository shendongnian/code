    private IDependency1 _dependency1;
    private IDependency2 _dependency2;
    private ClassToBeTested _classToBeTested;
    
    [SetUp]
    private override void SetUp()
    {
      base.SetUp();
      _dependency1 = MockRepository.GenerateMock<IDependency1>();
      _dependency2 = MockRepository.GenerateMock<IDependency2>();
    
      _classToBeTested = new ClassToBeTested(_dependency1, _dependency2);
    
    }
    
    [Test]
    public void TestCorrectFunctionOfProcess()
    {
    
      int input = 10000;
      IList<int> returnList = {1,2,3,4};
    
      // Arrange   
      _dependency1.Expect(d1 => d1.GetSomeList(input)).Return(returnList);
      _dependency2.Expect(d2 => d2.DoSomeProcessing(0)).IgnoreArguments().Return(1);
    
      // Act
      var outputList = _classToBeTested.Process(input);
    
      // Assert that output is correct for all mocked inputs
      Assert.IsNotNull(outputList, "Output list should not be null")
      
      // Assert correct behavior was _dependency1.GetSomeList(input) called?
      _dependency1.VerifyAllExpectations();
      _dependency2.VerifyAllExpectations();
    
    }
