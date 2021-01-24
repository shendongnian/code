     services.AddSingleton<ITokenManager, TokenManger>();
     services.AddScoped<ITokenProvider, TokenProvider>();
    public class TokenProvider : ITokenProvider
	{
		private readonly ITokenManager _tokenManager;
		public TokenProvider(ITokenManager tokenManager)
		{
			_tokenManager = tokenManager;
		}
    }
