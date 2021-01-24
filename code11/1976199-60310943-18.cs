    public void ConfigureServices(IServiceCollection services)
    {
        ClaimsPrincipal myprinc = new ClaimsPrincipal(  /* you'll need a ClaimsIdentity and some claims here probably */ );
        //or
        GenericPrincipal myprinc = new GenericPrincipal ( /* you'll need GenericIdentity and some roles here probably */ );
        services.AddTransient<IPrincipal>(
            provider => myprinc);
    
        // ...
    }
