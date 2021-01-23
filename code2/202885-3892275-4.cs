    class IntegrationResult
    {
          string Description { get; set; }
          string SuccessResultMessage { get; set; }
          string FailResultMessage { get; set; }
          public IntegrationResult(string desc, string success, string fail)
          {
              this.Description = desc;
              this.SuccessResultMessage = success;
              this.FailResultMessage = fail;
          }
          public bool ExecuteTest(Func<IntegrationResult, bool> test)
          {
              bool success = true;
              try
              {
                  this.Start();
                  success = test(this);
                  this.Stop();
                  this.ResultMessage = success ? 
                                          this.SuccessResultMessage : 
                                          this.FailResultMessage;
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
