    public bool foo(String username, String password) {
        string ADIPaddress = "[ipaddress]";
        ContextOptions options = ContextOptions.Negotiate;
        PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, AD_IPaddress, null, options, username, password);
        bool isAuthenticated = principalContext.ValidateCredentials(username, password, options);
        return isAuthenticated;
    }
