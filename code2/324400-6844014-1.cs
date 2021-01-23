    [Test]
    public void aaa_repeat_n_times_does_work_when_actual_greater_than_expected() {
      const Int32 ActualTimesToCall = 6;
      const Int32 ExpectedTimesToCall = 4;
  
      var mock = MockRepository.GenerateMock<IExample>();
  
      for (var i = 0; i < ActualTimesToCall; i++) {
          mock.ExampleMethod();
      }
    
      // This one fails (as expected)
      mock.AssertWasCalled(
          example => example.ExampleMethod(),
          options => options.Repeat.Times(ExpectedTimesToCall)
      );
    }
