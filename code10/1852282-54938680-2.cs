     public class CacheAuthorizeAttribute : AuthorizeAttribute
            {
                public CacheAuthorizeAttribute(params string[] roles)
                    : base()
                {
                    Roles = string.Join(",", roles);
                }
        
                public override void OnAuthorization(HttpActionContext actionContext)
                {
        
                    Dictionary<HttpStatusCode, string> response;
                    if (SkipAuthorization(actionContext))
                    {
                        return;
                    }
        
                    var userSessionManager = new UserCacheManager();
                    if (userSessionManager.ReValidateSession(out response))
                    {
                        base.OnAuthorization(actionContext);
                    }
                    else
                    {
                        ApiResponse apiResponse = new ApiResponse(response.Values.FirstOrDefault());
                        actionContext.Response = actionContext.ControllerContext.Request.CreateResponse(response.Keys.FirstOrDefault(), apiResponse);
                    }
               
    
     }
    
    
    /// <summary>
            /// Re-validates the user session. Usually called at each authorization request.
            /// If the session is not expired, extends it lifetime and returns true.
            /// If the session is expired or does not exist, return false.
            /// </summary>
            /// <returns>true if the session is valid</returns>
            public bool ReValidateSession(out Dictionary<HttpStatusCode, string> errorResponse)
            {
                
                errorResponse = new Dictionary<HttpStatusCode, string>();
                string authToken = this.GetCurrentBearerAuthrorizationToken();
                 ITokenDetailRepository tokenDetailRepository = new TokenDetailRepository();
                 ITokenDetailBL tokenDetailBl = new TokenDetailBL(tokenDetailRepository);
                 CachedData cachedData = new CachedData(tokenDetailBl);
                if (!string.IsNullOrEmpty(authToken))
                {
                    var currentUserId = this.GetCurrentUserId();
                    var getUserTokens = cachedData.GetAccessTokens();
                    if (!getUserTokens.ContainsKey(authToken))
                    {
                        //Get Data from DB
                        cachedData.GetAccessToken(authToken);
                        getUserTokens = cachedData.GetAccessTokens();
                    }
                    return CheckAccessToken(getUserTokens, authToken, out errorResponse);
                }
                else
                {
                    errorResponse.Add(HttpStatusCode.Gone, "Access token not found.");
                }
                return false;
            }
    
     private bool CheckAccessToken(Dictionary<string, string> accessTokenDictionary, string authToken, out Dictionary<HttpStatusCode, string> errorResponse)
            {
                errorResponse = new Dictionary<HttpStatusCode, string>();
                var hasToken = accessTokenDictionary.ContainsKey(authToken);
    
                if (hasToken)
                {
                    var getTokenValue = accessTokenDictionary[authToken];
                    var enCulture = new CultureInfo("en-US");
                    DateTime tokenAddedDate;
                    var isCorrectDate = DateTime.TryParseExact(getTokenValue.Split(new char[] { ':' }, 2)[1], "dd-MMM-yyyy,hh:mm tt", enCulture, DateTimeStyles.None, out tokenAddedDate);
                    if (isCorrectDate)
                    {
                        if (tokenAddedDate >= DateTime.UtcNow)
                        {
                            return true;
                        }
                        else
                        {
                            //Check Refresh token expired or not
                            errorResponse.Add(HttpStatusCode.Unauthorized, "Access token expired.");
                        }
                    }
                    else
                    {
                        errorResponse.Add(HttpStatusCode.Gone, "Invalid access token.");
                    }
                }
                else
                {
                    errorResponse.Add(HttpStatusCode.Gone, "Invalid access token.");
                }
                return false;
            }
