    /// <summary>
    /// Tests that an isolated template service cannot use the same application domain as the 
    /// main application domain.
    /// </summary>
    /// <remarks>
    /// An isolated template service will unload it's child application domain on Dispose. We need to ensure
    /// it doesn't attempt to unload the current application domain that it is running in. This may or may
    /// not be the main application application domain (but is very likely to be).
    /// </remarks>
    [Test]
    public void IsolatedTemplateService_WillThrowException_WhenUsingMainAppDomain()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            using (var service = new IsolatedTemplateService(() => AppDomain.CurrentDomain))
            { }
        });
    }
