    public interface IAuthenticated
    {
      public async Task<ApiResponse> GetPrivateData();
    }
    public interface IPublicAccess
    {
      public async Task<ApiResponse> GetPublicData();
    }
    public async Task<ApiResponse> IPublicAccess.GetPublicData()
    {
      var request = CreateRequest( "v1/public" );
      return await _httpClient.GetAsync( request );
    }
    
    public async Task<ApiResponse> IAuthenticated.GetPrivateData()
    {
      var request = CreateRequest( "v1/private" );
      return await _httpClient.GetAsync( request );
    }
    
    private ApiRequest CreateRequest( string endpoint )
    {
       var request = new ApiRequest( endpoint );
    
       // if (caller has RequiresAuthenticationAttribute)
       //    SignRequest( request, _credentials );
    
       return request;
    }
