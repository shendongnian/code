    public void Configuration(IAppBuilder app)
    {
        HttpListener listener = (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
                listener.AuthenticationSchemeSelectorDelegate = new 
        AuthenticationSchemeSelector(GetAuthenticationScheme);
    }
    
    private AuthenticationSchemes GetAuthenticationScheme(HttpListenerRequest httpRequest)
    {
        if(/* some logic... */){
            return AuthenticationSchemes.Anonymous;                    
        }
        else{
            return AuthenticationSchemes.IntegratedWindowsAuthentication;
        }
    }
