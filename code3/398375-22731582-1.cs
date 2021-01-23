    [TestFixture]
    public sealed class StringExtensionsTests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual("text_LaLa__lol________123______", "text LaLa (lol) á ñ $ 123 ٠١٢٣٤".ReplaceNonAlphanumeric('_'));
        }
    }
