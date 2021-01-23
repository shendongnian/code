    //inside MainPageLoad()
    var unitTestSettings = UnitTestSystem.CreateDefaultSettings();
    unitTestSettings.TestHarness.TestHarnessCompleted += TestRunCompletedCallback;
    var testPage = UnitTestSystem.CreateTestPage(unitTestSettings) as IMobileTestPage;
    void TestRunCompletedCallback(object sender, TestHarnessCompletedEventArgs e) {
        var testHarness = sender as UnitTestHarness;
        foreach (var result in testHarness.Results) {
            switch (result.Result) {
                case TestOutcome.Passed:
                case TestOutcome.Completed:
                    break;
                default:
                    // must be a failure of some kind
                    // perform some outputting
                    break;
             }
        }
    }
