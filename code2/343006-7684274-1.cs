    [Test]
    public void SomeTest()
    {
        // arrange
        ...
        File.ExistsImpl = (path) => true; // to just default to true for every call
        ...
        // act, then assert
        ...
    }
