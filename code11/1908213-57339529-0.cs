        public interface ITokenProvider
        {
        	public async Task<AccessToken> GetTokenAsync(string siteName, int accountId);
        }
        ...
        public async Task<HttpResponseMessage> SendAsync(string requestUri, string siteName, int accountId)
        {
          try
          {
            var accessToken = await _tokenProvider.GetTokenAsync(siteName, accountId);
        ...
        [Fact]
        public async Task ShouldReturnHttpResponseMessage_OnSendAsync()
        {
			var tokenProviderMock = new Mock<ITokenProvider>()
				.Setup(o => o.GetTokenAsync("siteName", 1000))
				.Returns(Constants.AllowedToken);
			_jaClient = new JaClient(tokenProviderMock.Object);...
