    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void SameOrder() // passes
        {
            IEnumerable<int> expected = new[] { 1, 9, 0, 4};
            IEnumerable<int> actual = new[] { 1, 9, 0, 4 };
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void WrongOrder() // fails
        {
            IEnumerable<int> expected = new[] { 1, 9, 0, 4 };
            IEnumerable<int> actual = new[] { 9, 0, 1, 4 };
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
