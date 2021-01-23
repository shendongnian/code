    [TestClass]
    public class TagCleanerTest
    {
        [TestMethod]
        public void Should_Clean_EM_Tag_That_Are_In_Sequence_Even_With_Spaces_In_Between()
        {
            var input = "<em>Administration</em> <em>Resource</em> Officer <em>paragraphs</em>";
            var expected = "<em>Administration Resource</em> Officer <em>paragraphs</em>";
            var sut = new TagCleaner();
            var actual = sut.CleanEM(input);
            Assert.AreEqual(expected, actual);
        }
    }
