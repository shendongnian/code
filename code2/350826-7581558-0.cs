    //inside MainPageLoad()
    ...
    var unitTestSettings = UnitTestSystem.CreateDefaultSettings();
    unitTestSettings.TestHarness.TestHarnessCompleted += TestRunCompletedCallback;
    var testPage = UnitTestSystem.CreateTestPage(unitTestSettings) as IMobileTestPage;
