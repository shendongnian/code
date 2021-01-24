    [Fact]
    public async Task ReturnsString() {
        // Arrange
        const string expected = "test";
        var sut = new ExampleClass();
                    
        var task = sut.GetFooAsync(); // launch tack and do not await
        sut.SetFoo(expected); // set expected value after GetFooAsync is called
        // Act
        var actual = await task;
        // Assert
        Assert.Equal(expected, actual);
    }
