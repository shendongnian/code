    public class GoogleController : ApplicationController
    {
        //
        // GET: /Google/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Authorize()
        {
            OAuthParameters parameters = BuildParameters();
            // build the token for unauthorized requests and generate the url
            GetUnauthorizedRequestToken(parameters);
            string authorizationUrl = OAuthUtil.CreateUserAuthorizationUrl(parameters);
            // store the parameters temporarily and redirect to google for authorization
            SaveParametersTokens(parameters);
            Response.Redirect(authorizationUrl);
            return View();
        }
        public ActionResult Oauth()
        {
            // retrieve and update the tokens for temporary authentication
            OAuthParameters parameters = BuildParameters();
            OAuthUtil.UpdateOAuthParametersFromCallback(Request.Url.Query, parameters);
            // finally, get the token we need b@#$!!!
            OAuthUtil.GetAccessToken(parameters);
            // save those tokens into the database
            SaveParametersTokens(parameters);
            // all the success in the world, return back
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteParametersTokens()
        {
            var oldTokens = (from t in context.GO_GoogleAuthorizeTokens select t);
            // if there is a token, call google to remove it
            /*if (oldTokens.Count() > 0)
            {
                GO_GoogleAuthorizeToken tokens = oldTokens.First();
                AuthSubUtil.revokeToken(tokens.Token, null);
            }*/
            // delete the tokens from the database
            context.GO_GoogleAuthorizeTokens.DeleteAllOnSubmit(oldTokens);
            context.SubmitChanges();
            // redirect to the administrator homepage when the tokens are deleted
            return RedirectToAction("Index", "Admin");
        }
        
        #region private helper methods
        
        private void GetUnauthorizedRequestToken(OAuthParameters parameters)
        {
            String requestTokenUrl = "https://www.google.com/accounts/OAuthGetRequestToken";
            Uri requestUri = new Uri(string.Format("{0}?scope={1}", requestTokenUrl, OAuthBase.EncodingPerRFC3986(parameters.Scope)));
            // callback is only needed when getting the request token
            bool callbackExists = false;
            if (!string.IsNullOrEmpty(parameters.Callback))
            {
                parameters.BaseProperties.Add(OAuthBase.OAuthCallbackKey, parameters.Callback);
                callbackExists = true;
            }
            string headers = OAuthUtil.GenerateHeader(requestUri, "GET", parameters);
            System.Net.WebRequest request = System.Net.WebRequest.Create(requestUri);
            request.Headers.Add(headers);
            System.Net.WebResponse response = request.GetResponse();
            string result = "";
            if (response != null)
            {
                System.IO.Stream responseStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(responseStream);
                result = reader.ReadToEnd();
            }
            if (callbackExists)
            {
                parameters.BaseProperties.Remove(OAuthBase.OAuthCallbackKey);
            }
            // split results and update parameters
            SortedDictionary<string, string> responseValues = OAuthBase.GetQueryParameters(result);
            parameters.Token = responseValues[OAuthBase.OAuthTokenKey];
            parameters.TokenSecret = responseValues[OAuthBase.OAuthTokenSecretKey];
        }
        private bool SaveParametersTokens(OAuthParameters parameters)
        {
            try
            {
                // first delete any old ones
                var oldTokens = (from t in context.GO_GoogleAuthorizeTokens select t);
                context.GO_GoogleAuthorizeTokens.DeleteAllOnSubmit(oldTokens);
                context.SubmitChanges();
                // now create a new one
                GO_GoogleAuthorizeToken newToken = new GO_GoogleAuthorizeToken
                {
                    Token = parameters.Token,
                    TokenSecret = parameters.TokenSecret
                };
                context.GO_GoogleAuthorizeTokens.InsertOnSubmit(newToken);
                context.SubmitChanges();
            }
            catch { return false; }
            return true;
        }
        private OAuthParameters BuildParameters()
        {
            // build the base parameters
            string scope = "https://www.google.com/calendar/feeds/ https://docs.google.com/feeds/ https://mail.google.com/mail/feed/atom/";
            string callback = String.Format("http://{0}/Google/Oauth", Request.Url.Authority);
            OAuthParameters parameters = new OAuthParameters
            {
                ConsumerKey = kConsumerKey,
                ConsumerSecret = kConsumerSecret,
                Scope = scope,
                Callback = callback,
                SignatureMethod = "HMAC-SHA1"
            };
            // check to see if we have saved tokens
            var tokens = (from a in context.GO_GoogleAuthorizeTokens select a);
            if (tokens.Count() > 0)
            {
                GO_GoogleAuthorizeToken token = tokens.First();
                parameters.Token = token.Token;
                parameters.TokenSecret = token.TokenSecret;
            }
            return parameters;
        }
        #endregion
    }
