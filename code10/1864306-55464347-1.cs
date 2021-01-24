    [Test]
    public void ExampleTest() {
        //Arrange
        var expected = 100;
        var test = new GameObject().AddComponent<MyScript>();
    
        test.testField = expected;
        //Act
        var actual = test.testField;
    
        //Assert
        Assert.AreEqual(expected, actual);
    }
