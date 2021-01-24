    [TestMethod]
    public void Should_GetDateTime_Given_Format() {
        //Arrange - using Moq
        string expected = "2020-02-22";
        string format = "yyyy-MM-dd";
        int columnNumber = 0;
        var target = Mock.Of<DbDataReader>(_ => _.GetString(columnNumber) == expected);
        //Act
        var actual = target.GetDateTime(columnNumber, format);
        //Assert - using FluentAssertions
        actual.ToString(format).Should().Be(expected);
    }
