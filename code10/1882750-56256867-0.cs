        options.Events.OnRedirectToIdentityProvider = (loginRedirectContext) =>
                    {
                        var servicesProvider = loginRedirectContext.HttpContext.RequestServices;
                        var tenantInfo = servicesProvider.GetRequiredService<IRequestContextTenantInfo>();
                        
    loginRedirectContext.ProtocolMessage.SetParameter("tenantId", tenantInfo.Id);
    
                        
                        return Task.FromResult(0);
                    };
