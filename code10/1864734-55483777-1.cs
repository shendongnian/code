    // This test will perma-hang if the exception is not thrown
    [TestMethod]
    [ExpectedException(typeof(OperationCanceledException))]
    public async Task TestMethod1()
    {
        var source = new Mock<IHttpManager>();
        source.Setup(s => s.TryCallThirdParty(It.IsAny<CancellationToken>())).Returns<CancellationToken>(
            async token =>
            {
                // Wait until the token is cancelled
                await Task.Delay(Timeout.Infinite, token);
            });
        var tcs = new CancellationTokenSource(1000);
        await new Caller().Get(source.Object, tcs.Token);
    }
