    public class FixedWSFederationAuthenticationModule : WSFederationAuthenticationModule
    {
		public override void RedirectToIdentityProvider(string uniqueId, string returnUrl, bool persist)
		{
			//This corrects WIF error ID3206 "A SignInResponse message may only redirect within the current web application:"
			//First Check if the request url doesn't end with a "/"
			if (!returnUrl.EndsWith("/"))
			{
				//Compare if Request Url +"/" is equal to the Realm, so only root access is corrected
				//https://localhost/AppName plus "/" is equal to https://localhost/AppName/
				//This is to avoid MVC urls
				if (String.Compare(System.Web.HttpContext.Current.Request.Url.AbsoluteUri + "/", base.Realm, StringComparison.InvariantCultureIgnoreCase) == 0)
				{
					//Add the trailing slash
					returnUrl += "/";
				}
			}
			base.RedirectToIdentityProvider(uniqueId, returnUrl, persist);
		}
	}
