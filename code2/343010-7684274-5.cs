    [Test]
    public void SomeTest()
    {
        // arrange
        ...
        File.ExistsImpl = (path) => true; // to just default to true for every call
        ...
        // act
        someClass.SomeMethod();
        // then assert
        ...
    }
