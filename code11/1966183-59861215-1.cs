    [TestFixture]
    public class ImmutableTest
    {
        [Test]
        public void Test()
        {
			var m = new Immutable("usd", "us");
            string s = m.Currency;
            Assert.AreEqual("usd", s);
        }
    }
