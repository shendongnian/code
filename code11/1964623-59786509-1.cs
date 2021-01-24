    [TestClass]
    public class RoundingTest
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenTwoItems_WhenAskingToRound_ThenItShouldReturnCorrectValue()
        {
            // arrange
            List<Item> items = new List<Item>
            {
                new Item { Price = 10.123m, Quantity = 10 },
                new Item { Price = 20.123m, Quantity = 20 }
            };
            // act
            decimal actual = Math.Round(items.Sum(x => x.Price * x.Quantity) / items.Sum(x => x.Quantity), 2);
            // assert
            actual.Should().Be(16.79m);
        }
    }
    public class Item
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
