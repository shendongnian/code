            [TestMethod]
            public async Task HandleAuthenticateAsync_CredentialsTryParseFails_ReturnsAuthenticateResultFail()
            {
                var context = new DefaultHttpContext();
                var authorizationHeader = new StringValues(String.Empty);
                context.Request.Headers.Add(HeaderNames.Authorization, authorizationHeader);
    
                await _handler.InitializeAsync(new AuthenticationScheme(BasicAuthenticationHandler.SchemeName, null, typeof(BasicAuthenticationHandler)), context);
                var result = await _handler.AuthenticateAsync();
    
                Assert.IsFalse(result.Succeeded);
                Assert.AreEqual("Basic authentication failed.  Unable to parse username and password.", result.Failure.Message);
            }
    
            [TestMethod]
            public async Task HandleAuthenticateAsync_PrincipalIsNull_ReturnsAuthenticateResultFail()
            {
                _principalProvider.Setup(m => m.GetClaimsPrincipalAsync(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>())).ReturnsAsync((ClaimsPrincipal)null);
    
                var context = new DefaultHttpContext();
                var authorizationHeader = new StringValues("Basic VGVzdFVzZXJOYW1lOlRlc3RQYXNzd29yZA==");
                context.Request.Headers.Add(HeaderNames.Authorization, authorizationHeader);
    
                await _handler.InitializeAsync(new AuthenticationScheme(BasicAuthenticationHandler.SchemeName, null, typeof(BasicAuthenticationHandler)), context);
                var result = await _handler.AuthenticateAsync();
    
                Assert.IsFalse(result.Succeeded);
                Assert.AreEqual("Basic authentication failed.  Invalid username and password.", result.Failure.Message);
            }
    
            [TestMethod]
            public async Task HandleAuthenticateAsync_PrincipalIsNull_ReturnsAuthenticateResultSuccessWithPrincipalInTicket()
            {
                var username = "TestUserName";
                var claims = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, BasicAuthenticationHandler.SchemeName);
                var claimsPrincipal = new ClaimsPrincipal(identity);
                _principalProvider.Setup(m => m.GetClaimsPrincipalAsync(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>())).ReturnsAsync(claimsPrincipal);
    
                var context = new DefaultHttpContext();
                var authorizationHeader = new StringValues("Basic VGVzdFVzZXJOYW1lOlRlc3RQYXNzd29yZA==");
                context.Request.Headers.Add(HeaderNames.Authorization, authorizationHeader);
    
                await _handler.InitializeAsync(new AuthenticationScheme(BasicAuthenticationHandler.SchemeName, null, typeof(BasicAuthenticationHandler)), context);
                var result = await _handler.AuthenticateAsync();
    
                Assert.IsTrue(result.Succeeded);
                Assert.AreEqual(BasicAuthenticationHandler.SchemeName, result.Ticket.AuthenticationScheme);
                Assert.AreEqual(username, result.Ticket.Principal.Identity.Name);
            }
