    [TestFixture]
    public class phpBBHashTestFixture
    {
        [Test]
        public void TestCanVerifyPhpBBPassword()
        {
            var cryptoService = new phpBBCryptoServiceProvider();
            Assert.That(cryptoService.phpbbCheckHash("a", "$H$9AE1X.4z5hqGj/RVdvzuYjxsJdMeFs."), Is.True);
            Assert.That(cryptoService.phpbbCheckHash("q1w2e3", "$H$9uAiKWrdcDomn7FEqujoPLYuBXvkzV0"), Is.True);
        }
    }
