    ulong token = 0;
    var principal = User as WindowsPrincipal;
    if ( principal != null )
    {
        var identity = (WindowsIdentity) principal.Identity;
        ViewBag.Identity = identity.Name;
        token = (ulong) identity.Token.ToInt64();
    }
    // Server 2008 or Vista required to use IAzClientContext3
    // Using token 0 uses app pool identity
    var _clientContext = (IAzClientContext3) _azManApp.InitializeClientContextFromToken( token );
