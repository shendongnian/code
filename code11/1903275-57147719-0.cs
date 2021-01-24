                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                **// This is needed for cookie-consent when embedded in a web-site(iFrame, Embed, Object)               
                options.ConsentCookie.SameSite = SameSiteMode.None;** 
            });
