     [Given(@"some test")]
    
      public void someTest(){
          if (BindingClass.scenarioContext.ScenarioInfo.Tags.Contains("ignore"))
                {
                    var unitTestRuntimeProvider = (IUnitTestRuntimeProvider)
                    RediTestControl._scenarioContext.GetBindingInstance((typeof(IUnitTestRuntimeProvider)));
                    unitTestRuntimeProvider.TestIgnore("ignored");
                }
      }
