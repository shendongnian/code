      class DSPrincipals
      {
        static void Main(string[] args)
        {
          /* Retreiving a principal context
           */
          PrincipalContext domainContextMonou = new PrincipalContext(ContextType.Domain, "WM2008R2ENT:389", "ou=Monou,dc=dom,dc=fr", "jpb", "pass@1w0rd01");
    
    
          /* Create a user principal object
           */
          slxUser aSlxUser = new slxUser(domainContextMonou, "W.Zeidan", "pass@1w0rd01", true);
    
          /* assign some properties to the user principal
           */
          aSlxUser.GivenName = "Wessam";
          aSlxUser.Surname = "Zeidan";
          aSlxUser.streetAddress = "Add1";
    
    
          /* Force the user to change password at next logon
           */
          aSlxUser.ExpirePasswordNow();
    
          /* save the user to the directory
           */
          aSlxUser.Save();
    
    
          Console.ReadLine();
        }
      }
    
      [DirectoryObjectClass("user")]
      [DirectoryRdnPrefix("CN")]
      class slxUser : UserPrincipal
      {
        public slxUser(PrincipalContext context)
          : base(context) { }
    
        public slxUser(PrincipalContext context, string samAccountName, string password,  bool enabled ) : base(context, samAccountName, password, enabled)
        {
        }
    
        [DirectoryProperty("streetAddress")]
        public string streetAddress
        {
          get
          {
            object[] result = this.ExtensionGet("streetAddress");
            if (result != null)
            {
              return (string)result[0];
            }
            else
            {
              return null;
            }
          }
          set { this.ExtensionSet("streetAddress", value); }
        }
      }
