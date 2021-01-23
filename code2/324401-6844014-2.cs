    [Test]
    public void expect_repeat_n_times_does_not_work_when_actual_greater_than_expected() {
      const Int32 ActualTimesToCall = 6;
      const Int32 ExpectedTimesToCall = 4;
        
      var mock = MockRepository.GenerateMock<IExample>();
      mock.Expect(example => example.ExampleMethod()).Repeat.Times(ExpectedTimesToCall);
      
      for (var i = 0; i < ActualTimesToCall; i++) {
          mock.ExampleMethod();
      }
        
      // [?] This one passes
      mock.VerifyAllExpectations();
    }
