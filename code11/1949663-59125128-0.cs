    [Fact]
    public void CanChangeProductName() {
        // Arrange
        var expected = "NewName";
        var subject = new Product() {
            Name = "Name",
            Price = 180M
        };
        
        // Act
        subject.Name = expected;
        var actual = subject.Name;
        // Assert
        Assert.Equal(expected, actual);
    }
