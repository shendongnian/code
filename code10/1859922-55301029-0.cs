    services.AddAuthentication().AddOpenIdConnect(Constants.MyIdpName, Constants.MyIdpName, options => {
    ***           
    options.Events = new OpenIdConnectEvents {
         OnRedirectToIdentityProvider = ctx => {
              var rcf = ctx.HttpContext.Features.Get<IRequestCultureFeature>();
                  if (rcf.Provider != null) {
                        string lng = rcf.RequestCulture.Culture.TwoLetterISOLanguageName;
                        ctx.ProtocolMessage.Parameters.Add("ui_locales", lng == "nn" || lng == "nb" ? "no" : lng);
                  }
                  return Task.CompletedTask;
              }
         }
    }
