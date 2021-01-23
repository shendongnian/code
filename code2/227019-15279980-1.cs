    /// <summary>
    /// Provides a workaround for a bug in the standard authentication module.
    /// </summary>
    /// <remarks>
    /// This class corrects WIF error ID3206 "A SignInResponse message may only
    /// redirect within the current web application..."
    /// WSFAM produces the error when the ReturnUrl is the root of the web application,
    /// but doesn't have a trailing slash. For instance, "/app" is considered incorrect
    /// by WSFAM whereas "/app/" is correct.
    /// </remarks>
    public class FixedWsFederationAuthenticationModule : WSFederationAuthenticationModule
    {
    	/// <summary>
    	/// Extracts the URL of the page that was originally requested from
    	/// the sign-in response.
    	/// </summary>
    	/// <returns>
    	/// The URL of the page that was originally requested by the client.
    	/// This is the URL (at the relying party) to which the client should
    	/// be redirected following successful sign-in.
    	/// </returns>
    	/// <param name="request">
    	/// The HTTP request that contains a form POST, which contains the
    	/// WS-Federation sign-in response message.
    	/// </param>
    	protected override string GetReturnUrlFromResponse(HttpRequestBase request)
    	{
    		string returnUrl = base.GetReturnUrlFromResponse(request);
    
    		// First Check if the request url doesn't end with a "/"
    		if (!string.IsNullOrEmpty(returnUrl) && !returnUrl.EndsWith("/"))
    		{
    			// Compare if (return Url +"/") is equal to the Realm path,
    			// so only root access is corrected.
    			// /AppName plus "/" is equal to /AppName/
    			// This is to avoid MVC urls.
    			if (string.Compare(
    				returnUrl + "/",
    				new Uri(Realm).LocalPath,
    				StringComparison.InvariantCultureIgnoreCase) == 0)
    			{
    				// Add the trailing slash.
    				returnUrl += "/";
    			}
    		}
    
    		return returnUrl;
    	}
    }
