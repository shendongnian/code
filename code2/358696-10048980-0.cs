    public static class SecurityEx
    {
        public static SecurityIdentifier DomainSId
        {
            get
            {               
                var administratorAcount = new NTAccount(GetDomainName(), "administrator");
                var administratorSId = (SecurityIdentifier) administratorAcount.Translate(typeof (SecurityIdentifier));
                return administratorSId.AccountDomainSid;
            }
        }
        internal static string GetDomainName()
        {
            //could be other way to get the domain name through Environment.UserDomainName etc...
            return IPGlobalProperties.GetIPGlobalProperties().DomainName;
        }
