    public static readonly ServiceProviderDescription ServiceDescription = new ServiceProviderDescription
    {
        ProtocolVersion = ProtocolVersion.V10a,
        RequestTokenEndpoint = new MessageReceivingEndpoint(oAuthBase + "/oauth_request.php", HttpDeliveryMethods.PostRequest),
        UserAuthorizationEndpoint = new MessageReceivingEndpoint(oAuthBase + "/oauth_authorize.php", HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
        AccessTokenEndpoint = new MessageReceivingEndpoint(oAuthBase + "/oauth_access.php", HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
        TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new PlaintextSigningBindingElement() }
    };
    public static void RequestAuthorization(WebConsumer consumer)
    {
        if (consumer == null)
        {
            throw new ArgumentNullException("consumer");
        }
        var extraParameters = new Dictionary<string, string> {
            { "oauth_signature_method", "PLAINTEXT" },
        };
        Uri callback = Util.GetCallbackUrlFromContext();
        var request = consumer.PrepareRequestUserAuthorization(callback, extraParameters, null);
        consumer.Channel.Send(request);
    }
