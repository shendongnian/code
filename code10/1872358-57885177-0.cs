csharp
...
runner.TestCaseFilter = this.Filter;
...
        /// <summary>
        /// Filters the specified test case.
        /// </summary>
        /// <param name="testCase">The test case.</param>
        /// <returns><c>true</c> if test case should be executed, <c>false</c> otherwise.</returns>
        protected bool Filter(ITestCase testCase)
        {
            if(testCase.TestMethod.TestClass.Class.Name.StartsWith("DoNotTest")) 
            {
                return false;
            }
            return true;
        }
You can also use the method to track all discovered test cases. 
