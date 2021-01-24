    public void DoStuffWithListOfTestScores(List<TestResult> testResults)
    {
        // testResults is in some specific order and we don't want to change it.
        AddBonusForFinishingFaster(testResults);
        // the order of testResults hasn't changed.
    }
    private void AddBonusForFinishingFaster(IEnumerable<TestResult> testResults)
    {
        var fastestTen = testResults.OrderBy(result => result.Duration).Take(10);
        foreach (var result in fastestTen)
        {
            result.Score += 10;
        }
    }
