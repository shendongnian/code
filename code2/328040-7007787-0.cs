    [Test]
    public void InstanciatingWithNullParameterThrowsException()
    {
        bool isArgumentNullExceptionThrown = false;
        try
        {
           new CachedStreamingEnumerable<int>(null);
        }
        catch (ArgumentNullException)
        {
            isArgumentNullExceptionThrown = true;
        }
        Assert.That(isArgumentNullExceptionThrown);
    }
