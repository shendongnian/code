    [Test]
    public void TestServerIsUp()
    {
        var factory = new ChannelFactory<IMyServiceInterface> (configSectionName);
        factory.Open ();
        return factory.CreateChannel ();
    }
