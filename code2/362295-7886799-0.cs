    private static SecurityToken GetIdPToken()
        {
            var factory = new WSTrustChannelFactory(
                new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
                "https://systemidp.dk/Issuer.svc");
            factory.TrustVersion = TrustVersion.WSTrust13;
        
            factory.Credentials.UserName.UserName = "LITWARE\\rick";
            factory.Credentials.UserName.Password = "thisPasswordIsNotChecked";
            var rst = new RequestSecurityToken
            {
                RequestType = WSTrust13Constants.RequestTypes.Issue,
                AppliesTo = new EndpointAddress("https://adfsfqdn/adfs/services/trust"),
                KeyType = WSTrust13Constants.KeyTypes.Symmetric,
                ReplyTo = "https://adfsfqdn/adfs/services/trust/13/issuedtokenmixedsymmetricbasic256/"
            };
            factory.ConfigureChannelFactory();
            var channel = factory.CreateChannel();
            return channel.Issue(rst);
        }
        private static SecurityToken GetRSTSToken(SecurityToken idpToken)
        {
            var binding = new IssuedTokenWSTrustBinding();
            binding.SecurityMode = SecurityMode.TransportWithMessageCredential;
            var factory = new WSTrustChannelFactory(
                binding,
                "https://adfsfqdn/adfs/services/trust/13/issuedtokenmixedsymmetricbasic256/");
            factory.TrustVersion = TrustVersion.WSTrust13;
            factory.Credentials.SupportInteractive = false;
            var rst = new RequestSecurityToken
            {
                RequestType = WSTrust13Constants.RequestTypes.Issue,
                AppliesTo = new EndpointAddress("https://services.dk/WebService.svc"),
                KeyType = WSTrust13Constants.KeyTypes.Symmetric
            };
            factory.ConfigureChannelFactory();
            var channel = factory.CreateChannelWithIssuedToken(idpToken);
            return channel.Issue(rst);
        }
