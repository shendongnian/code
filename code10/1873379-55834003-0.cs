    // And Step
    private void AndThePageCountIs(int expectedResults)
    {
       actual = _foo.Setup(x => x.ThenIAmShownResultsFor()).Returns(expectedResults);
       Assert.AreEqual(expectedResults, actual);
    }
