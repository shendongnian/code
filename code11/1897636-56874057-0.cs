    interface ITokenService
    {
        Task<string> GetAccessToken(string resource);
    }
    class AzureTokenService : ITokenService
    {
        AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
        public async Task<string> GetAccessToken(string resource)
        {
            return await provider.GetAccessTokenAsync(resource);
        }
    }
