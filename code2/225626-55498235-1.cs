    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void ToLowerFirst_ShouldReturnCorrectValue()
            => "ABCD"
                .ToLowerFirst()
                .Should()
                .Be("aBCD");
        [TestMethod]
        public void ToLowerFirst_WhenStringIsEmpty_ShouldReturnCorrectValue()
            => string.Empty
                .ToLowerFirst()
                .Should()
                .Be(string.Empty);
    }
