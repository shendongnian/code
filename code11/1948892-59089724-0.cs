    public class SeleniumTestMethodAttribute : TestMethodAttribute
    {
         public override TestResult[] Execute(ITestMethod testMethod)
         {
            try {
                 base.Execute(testMethod);
            }
            catch (WebDriverTimeoutException webDriverTimeoutException)
            {                    
                testCaseStep.ErrorMessage = $@"""Exception Occoured in Method: 
                    '{MethodBase.GetCurrentMethod().Name}' with Exception: '{webDriverTimeoutException.StackTrace}'                      
                        ""WebDriverTimeoutException.InnerException is::"" {webDriverTimeoutException.InnerException}                        
                    ""Exception occured due to timeout""";
            }
        }
    }
