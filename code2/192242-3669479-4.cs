    public class MyFakeDataAccessor : IDatabaseAccessor
    {
        public IList<Thing> GetThings()
        {
            // Return a fake/pretend list of things for testing
            return new List<Thing>()
            {
                new Thing("Thing 1"),
                new Thing("Thing 2"),
                new Thing("Thing 3"),
                new Thing("Thing 4")
            };
        }
    
        // Other methods (snip)
    }
    
    [Test]
    public void Should_Return_8_With_Four_Things_In_Database()
    {
        // Arrange
        IDatabaseAccessor fakeData = new MyFakeDataAccessor();
        ComplexAlgorithm algorithm = new ComplexAlgorithm(fakeData);
        int expectedValue = 8;
    
        // Act
        int actualValue = algorithm.RunAlgorithm();
    
        // Assert
        Assert.AreEqual(expectedValue, actualValue);
    }
