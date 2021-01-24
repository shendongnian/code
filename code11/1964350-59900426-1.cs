     [Given(@"some common step for web and mobile")]
    
      public void someTest(){
          if (BindingClass.scenarioContext.ScenarioInfo.Tags.Contains("ignore"))
                {
                    var unitTestRuntimeProvider = (IUnitTestRuntimeProvider)
                    RediTestControl._scenarioContext.GetBindingInstance((typeof(IUnitTestRuntimeProvider)));
                    unitTestRuntimeProvider.TestIgnore("ignored");
                }
            else {
                   //initiate appium driver or webDriver
                }
      }
