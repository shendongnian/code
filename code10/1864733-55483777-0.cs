    // This test will perma-hang if the exception is not thrown
    [TestMethod]
    [ExpectedException(typeof(OperationCanceledException))]
    public async Task TestMethod1()
    {
        var source = new Mock<IHttpManager>();
        source.Setup(s => s.TryCallThirdParty(It.IsAny<CancellationToken>())).Returns<CancellationToken>(
            async token =>
            {
                // Spin until the token is cancelled
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    // Add some delay to make this not-CPU-bound
                    await Task.Delay(100);
                }
            });
        var tcs = new CancellationTokenSource(1000);
        await new Caller().Get(source.Object, tcs.Token);
    }
