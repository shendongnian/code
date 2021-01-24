    public class Turboencabulator : IEncabulator
    {
        private readonly HttpClient httpClient;
        public Turboencabulator( IHttpClientFactory hcf )
        {
            this.httpClient = hcf.CreateClient();
            this.httpClient.DefaultRequestHeaders.Add( "Authorization", "my-secret-bearer-token" );
            this.httpClient.BaseAddress = "https://api1.example.com";
        }
        public async InverseReactiveCurrent( UnilateralPhaseDetractor upd )
        {
            await this.httpClient.GetAsync( etc )
        }
    }
    public class SecretelyDivertDataToTheNsaEncabulator : IEncabulator
    {
        private readonly HttpClient httpClientReal;
        private readonly HttpClient httpClientNsa;
        public SecretNsaClientService( IHttpClientFactory hcf )
        {
            this.httpClientReal = hcf.CreateClient();
            this.httpClientReal.DefaultRequestHeaders.Add( "Authorization", "a-different-secret-bearer-token" );
            this.httpClientReal.BaseAddress = "https://api1.example.com";
            this.httpClientNsa = hcf.CreateClient();
            this.httpClientReal.DefaultRequestHeaders.Add( "Authorization", "TODO: it's on a postit note on my desk viewable from outside the building" );
            this.httpClientReal.BaseAddress = "https://totallylegit.nsa.gov";
        }
        public async InverseReactiveCurrent( UnilateralPhaseDetractor upd )
        {
            await this.httpClientNsa.GetAsync( etc )
            await this.httpClientReal.GetAsync( etc )
        }
    }
