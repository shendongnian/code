    options.Events.OnRedirectToIdentityProviderForSignOut = async context =>
    {
       var user = context.HttpContext.User;
    
       // Avoid displaying the select account dialog
       context.ProtocolMessage.LoginHint = user.GetLoginHint();
       context.ProtocolMessage.DomainHint = user.GetDomainHint();
       await Task.FromResult(0);
    };
