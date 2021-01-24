    [Fact]
    public async Task Test1Async() {
        //Arrange
        var prices = new List<Price> {
            new Price {
                Amount = 39.71,
                CustomerAccount = "010324",
                ItemId = "10103001",
                Id = 1,
                ItemInternalId = "test",
                ModifiedDateTime = new System.DateTime()
            },
            new Price
            {
                Amount = 57.09,
                CustomerAccount = "010324",
                ItemId = "10103001",
                Id = 2,
                ItemInternalId = "test2",
                ModifiedDateTime = new System.DateTime()
            }
        };
        var options = new DbContextOptionsBuilder<MyContext>()
                    .UseInMemoryDatabase(databaseName: "FekaConnectionString")
                    .Options;
        var context = new MyContext(options);
        //populate
        foreach(var price in prices) {
            context.Prices.Add(price);
        }
        await context.SaveChangesAsync();
        
        var repository = new PriceRepository(mockContext.Object);
        var list = new List<string>
        {
            "10103001"
        };
        //Act
        var result = await repository.GetPricesAsync(list, "010324");
        //Assert
        Assert.Single(result);
    }
