    public class WebService<TWebServiceClient, TWebService, TUser>
        where TWebService : class
        where TWebServiceClient : class, new()
        where TUser : class, new() {
        /// <summary>
        /// Create user object model
        /// </summary>
        private static readonly Func<string, string, TUser> createUser =
            ExpressionHelpers.CreateUserDelegate<TUser>();
        /// <summary>
        /// Encrypt provided value using <see cref="TWebService"/>
        /// </summary>
        private static readonly Func<TWebService, string, Task<string>> encryptValueAsync =
            ExpressionHelpers.CreateEncryptValueDelegate<TWebService>();
        private readonly IWebServiceFactory serviceFactory;
        private readonly IClientFactory clientFactory;
        Lazy<TWebServiceClient> client;
        public WebService(IWebServiceFactory serviceFactory, IClientFactory clientFactory) {
            this.serviceFactory = serviceFactory ?? throw new ArgumentNullException(nameof(serviceFactory));
            this.clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            client = new Lazy<TWebServiceClient>(() => clientFactory.Create<TWebServiceClient>());
        }
        public async Task<TResponse> SearchClaimAsync<TResponse>(WebServiceOptions options) {
            TWebService webService = serviceFactory.Create<TWebService>(options.URL);
            TUser user = createUser(
                await encryptValueAsync(webService, options.UserName),
                await encryptValueAsync(webService, options.Password)
            );
            Func<TWebServiceClient, TUser, Task<TResponse>> claimSearchAsync =
                ExpressionHelpers.CreateClaimSearchDelegate<TWebServiceClient, TUser, TResponse>();
            TResponse response = await claimSearchAsync.Invoke(client.Value, user);
            return response;
        }
        
        //...other generic members to be done
    }
    
    public class WebServiceOptions {
        public string URL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
