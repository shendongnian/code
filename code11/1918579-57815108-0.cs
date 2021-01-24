    [Fact]
    public void AddToKartMethod() {
        //Arrange
        var expected = "item";
        //Act
        List<KartItem> items = AddToKart.PutItemInKart(expected, 3, 4.5);
        string actual = items[0].Item;
        //Assert
        Assert.Equal(expected, actual);
    }
