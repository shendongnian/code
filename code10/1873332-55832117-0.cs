    [Theory]
    [InlineData("atv,atv,atv,hdm", "249.00")]
    [InlineData("nx9,nx9,atv,nx9,nx9,nx9", "531.00")]
    [InlineData("nx9,nx9,atv,nx9,nx9,nx9,nx9", "698.00")]
    public void Buy3Pay2(string input, string expected) {
        //Arrange
        var co = new Checkout(rules);
        var stock = input.Split(',');
        foreach (var item in stock) {
            var product = products.SingleOrDefault(p => string.Compare(item, p.SKU, true) == 0);
            Item realItem = new Item() {
                Name = product.Name,
                SKU = product.SKU,
                Price = product.Price
            };
            realItem.ID = Guid.NewGuid().ToString();
            co.Scan(realItem);
        }
        //Act
        var total = co.Total();
        //Assert
        total.Should().Be(Convert.ToDecimal(expected));            
    }
