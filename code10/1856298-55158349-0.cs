    public class IdentityExtension : IIdentity
    {       
        public IdentityExtension()
        { }
        public IdentityExtension(string name)
        {
            this.Name = name;
        }
        public string AuthenticationType => "Kerberos";
        public bool IsAuthenticated => true;
        public string Name { get; set; }
    }
