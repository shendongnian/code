    [TestMethod]
    public void TestSerialize()
    {
        // arrange
        var sb = new StringBuilder();
        using (var writer = new StringWriter(sb))
        {
            this.attempt = new RetryAttempt("1234", 4);
            this.attempts = new List<RetryAttempt>() { attempt };
            this.xmlStore = new XmlRetryFileStore(RetryType.Download);
            this.xmlStore.Save(writer, this.attempts);
        }
        string actual = sb.ToString();
        // TODO: assert on the resulting XML
    }
