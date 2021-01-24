    public void DoStuffWithListOfTestScores(List<TestResult> testScores)
    {
        // testScores is in some specific order and we don't want to change it.
        AddBonusForFinishingFaster(testScores);
    }
    private void AddBonusForFinishingFaster(IEnumerable<TestResult> testScores)
    {
        var fastest = testScores.OrderBy(score => score.Duration).Take(10);
        foreach(var result in fastest)
        {
            result.Score += 10;
        }
    }
