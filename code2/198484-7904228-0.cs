    public static class ETradeConsumer
    	{
    		public static string AccessUrl { get { return "https://etws.etrade.com/oauth/access_token"; } }
    		public static string RequestUrl { get { return "https://etws.etrade.com/oauth/request_token"; } }
    		public static string UserAuthorizedUrl { get { return "https://us.etrade.com/e/t/etws/authorize"; } }
    
    		public static ServiceProviderDescription CreateServiceDescription()
    		{
    			return new ServiceProviderDescription
    			{
    				AccessTokenEndpoint = new MessageReceivingEndpoint(AccessUrl, HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
    				ProtocolVersion = ProtocolVersion.V10a,
    				RequestTokenEndpoint = new MessageReceivingEndpoint(RequestUrl, HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
    				TamperProtectionElements = new ITamperProtectionChannelBindingElement[] {new HmacSha1SigningBindingElement() },
    				UserAuthorizationEndpoint = new MessageReceivingEndpoint(UserAuthorizedUrl, HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest)
    			};
    		}
    	}
