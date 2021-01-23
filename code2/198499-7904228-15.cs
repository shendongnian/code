    public static class ETradeConsumer
    {
        public static string AccessUrl 
        { 
            get 
            { 
                return "https://etws.etrade.com/oauth/access_token"; 
            } 
        }
	
        public static string RequestUrl 
        { 
            get 
            { 
                return "https://etws.etrade.com/oauth/request_token"; 
            } 
        }
	public static string UserAuthorizedUrl 
        {  
            get 
            { 
                return "https://us.etrade.com/e/t/etws/authorize"; 
            } 
        }
	private static readonly ServiceProviderDescription ServiceProviderDescription = new ServiceProviderDescription()
	{
	    AccessTokenEndpoint = new MessageReceivingEndpoint(AccessUrl, HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
	    ProtocolVersion = ProtocolVersion.V10a,
	    RequestTokenEndpoint = new MessageReceivingEndpoint(RequestUrl, HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
	    TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() },
	    UserAuthorizationEndpoint = new MessageReceivingEndpoint(new Uri(UserAuthorizedUrl), HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest)
	};
	public static DesktopConsumer CreateConsumer(IConsumerTokenManager tokenManager)
	{
	    return new DesktopConsumer(ServiceProviderDescription, tokenManager);
	}
	public static Uri PrepareRequestAuthorization(DesktopConsumer consumer, out string requestToken)
	{
	    if (consumer == null)
	    {
	        throw new ArgumentNullException("consumer");
	    }
	
            Uri authorizationUrl = consumer.RequestUserAuthorization(null, null, out requestToken);
	    authorizationUrl = new Uri(string.Format("{0}?key={1}&token={2}", ServiceProviderDescription.UserAuthorizationEndpoint.Location.AbsoluteUri, consumer.TokenManager.ConsumerKey, requestToken));
	    return authorizationUrl;
	}
	public static AuthorizedTokenResponse CompleteAuthorization(DesktopConsumer consumer, string requestToken, string userCode)
	    {
	 	var customServiceDescription = new ServiceProviderDescription
		{
	    	    RequestTokenEndpoint = ServiceProviderDescription.RequestTokenEndpoint,
		    UserAuthorizationEndpoint =
					new MessageReceivingEndpoint(
					string.Format("{0}?key={1}&token={2}",  ServiceProviderDescription.UserAuthorizationEndpoint.Location.AbsoluteUri,
					              consumer.TokenManager.ConsumerKey, requestToken),
					HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
		    AccessTokenEndpoint = new MessageReceivingEndpoint(
			ServiceProviderDescription.AccessTokenEndpoint.Location.AbsoluteUri + "?oauth_verifier" + userCode + string.Empty,
					HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest),
		    TamperProtectionElements = ServiceProviderDescription.TamperProtectionElements,
		    ProtocolVersion = ProtocolVersion.V10a
		};
		var customConsumer = new DesktopConsumer(customServiceDescription, consumer.TokenManager);
		var response = customConsumer.ProcessUserAuthorization(requestToken, userCode);
		return response;
	    }
	}
