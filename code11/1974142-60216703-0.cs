    public class OpenIdConnectPostConfigureOptions : IPostConfigureOptions<OpenIdConnectOptions>
    {
        private readonly ISecretsService _secretsService;
        public OpenIdConnectPostConfigureOptions(ISecretsService secretsService)
        {
            _secretsService = secretsService;
        }
        public async void PostConfigure(string name, OpenIdConnectOptions options)
        {
            options.ClientSecret = await _secretsService.Get("clientSecret");
        }
    }
