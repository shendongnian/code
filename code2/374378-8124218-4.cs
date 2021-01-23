    [TestFixture]
    public class ManualParserTests
    {
        [Test]
        public void Parse_GivenStringWithNoQuotesAndNoCommas_ShouldReturnThatString()
        {
            // Arrange
            var parser = new ManualParser();
            // Act
            string[] result = parser.Parse("This is my data").ToArray();
            // Assert
            Assert.AreEqual(1, result.Length, "Should only be one column returned");
            Assert.AreEqual("This is my data", result[0], "Incorrect value is returned");
        }
        [Test]
        public void Parse_GivenStringWithNoQuotesAndOneComma_ShouldReturnTwoColumns()
        {
            // Arrange
            var parser = new ManualParser();
            // Act
            string[] result = parser.Parse("This is, my data").ToArray();
            // Assert
            Assert.AreEqual(2, result.Length, "Should be 2 columns returned");
            Assert.AreEqual("This is", result[0], "First value is incorrect");
            Assert.AreEqual("my data", result[1], "Second value is incorrect");
        }
        [Test]
        public void Parse_GivenStringWithQuotesAndNoCommas_ShouldReturnColumnWithoutQuotes()
        {
            // Arrange
            var parser = new ManualParser();
            // Act
            string[] result = parser.Parse("\"This is my data\"").ToArray();
            // Assert
            Assert.AreEqual(1, result.Length, "Should be 1 column returned");
            Assert.AreEqual("This is my data", result[0], "Value is incorrect");
        }
        [Test]
        public void Parse_GivenStringWithQuotesAndCommas_ShouldReturnColumnsWithoutQuotes()
        {
            // Arrange
            var parser = new ManualParser();
            // Act
            string[] result = parser.Parse("\"This is\", my data").ToArray();
            // Assert
            Assert.AreEqual(2, result.Length, "Should be 2 columns returned");
            Assert.AreEqual("This is", result[0], "First value is incorrect");
            Assert.AreEqual("my data", result[1], "Second value is incorrect");
        }
        [Test]
        public void Parse_GivenStringWithQuotesContainingCommasAndCommas_ShouldReturnColumnsWithoutQuotes()
        {
            // Arrange
            var parser = new ManualParser();
            // Act
            string[] result = parser.Parse("\"This, is\", my data").ToArray();
            // Assert
            Assert.AreEqual(2, result.Length, "Should be 2 columns returned");
            Assert.AreEqual("This, is", result[0], "First value is incorrect");
            Assert.AreEqual("my data", result[1], "Second value is incorrect");
        }
    }
