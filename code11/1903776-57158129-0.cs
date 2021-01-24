    TestCaseResults results = new TestCaseReults()
    {
         TestCaseTitle = "test",
         AutomatedTestName = "name",
         TestCase = new ShallowReference(id: "32"),
         TestPoint = new ShallowReference(id: "1"),
         Outcome = "Passed"
    }
    List<TestCaseResult> list = new List<TestCaseResult>();
    list.add(results);
    var response = test.AddTestResultsToTestRunAsync(list.ToArray(), "project", 3214 // Test Run ID).Result;
