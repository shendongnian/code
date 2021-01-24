            [TestMethod]
            public async Task HandleAuthenticateAsync_NoAuthorizationHeader_ReturnsAuthenticateResultFail()
            {
                var context = new DefaultHttpContext();
    
                await _handler.InitializeAsync(new AuthenticationScheme(BasicAuthenticationHandler.SchemeName, null, typeof(BasicAuthenticationHandler)), context);
                var result = await _handler.AuthenticateAsync();
    
                Assert.IsFalse(result.Succeeded);
                Assert.AreEqual("Basic authentication failed.  Authorization header is missing.", result.Failure.Message);
            }
