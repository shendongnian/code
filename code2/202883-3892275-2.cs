    class IntegrationResult
    {
          public bool ExecuteTest(Action<IntegrationResult> test)
          {
              bool success = true;
              try
              {
                  test(this);
                  this.TestPassed = true;
              }
              catch(Exception e)
              {
                   this.TestPassed = false;
                   this.ResultMessage = String.Format("Error: {0}", e.Message);
                   success = false;
              }
              return success;
          }
           ...
