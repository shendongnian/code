    [AllowAnonymous]
            [HttpPost]
            public IHttpActionResult GetAccessToken(RefreshTokenModel getRefreshToken)
            {
                ApiResponse apiResponse = new ApiResponse();
                apiResponse.Message = "Your session has expired. Kindly login again.";
                try
                {
                    var getHashToken = GenerateHash.GetHash(getRefreshToken.RefreshToken);
                    var getRefreshTokenDetails = tokenDetailBl.GetRefreshTokenDetail(getHashToken);
                    if (getRefreshTokenDetails != null && getRefreshTokenDetails.ExpiresUtc > DateTime.UtcNow && !string.IsNullOrEmpty(getRefreshTokenDetails.ProtectedTicket))
                    {
                        if (getRefreshTokenDetails.DeviceType == getRefreshToken.DeviceType)
                        {
                            var currentTime = DateTime.UtcNow;
                            var refreshTokenLifeTime = Convert.ToDouble(ConfigurationManager.AppSettings["RefreshTokenExpireTime"]);
                            var tokenExpiration = Convert.ToDouble(ConfigurationManager.AppSettings["AccessTokenExpireTime"]);
                            ApiIdentityManager apiIdentityManager = new ApiIdentityManager();
    
                            var tokenData = JsonConvert.SerializeObject(new { Ticket = getRefreshTokenDetails.ProtectedTicket, DeviceId = getRefreshTokenDetails.DeviceId });
                            var getIdentityToken = apiIdentityManager.GetRefreshToken(tokenData);
    
                            // Delete Old Tokens
                            tokenDetailBl.DeleteAccessTokenByDevice(getRefreshTokenDetails.DeviceId);
                            var refreshToken = new RefreshToken()
                            {
                                RefreshTokenId = GenerateHash.GetHash(getIdentityToken.RefreshToken),
                                DeviceId = getRefreshTokenDetails.DeviceId,
                                DeviceType = getRefreshToken.DeviceType,
                                UserId = getRefreshTokenDetails.UserId,
                                IssuedUtc = currentTime,
                                ExpiresUtc = currentTime.AddMinutes(Convert.ToDouble(refreshTokenLifeTime)),
                                ProtectedTicket = getIdentityToken.Ticket
                            };
    
                            //Save new tokens
                            tokenDetailBl.SaveAccessToken(new TokenDetail
                            {
                                AccessToken = getIdentityToken.AccessToken,
                                CreatedOn = DateTime.UtcNow,
                                UserId = getRefreshTokenDetails.UserId,
                                DeviceId = getRefreshTokenDetails.DeviceId,
                                DeviceType = getRefreshToken.DeviceType
                            });
                            tokenDetailBl.SaveRefreshToken(refreshToken);
    
                            //Get token cache.
                            CachedData cachedData = new CachedData(tokenDetailBl);
                            var getAllToken = cachedData.GetAccessTokens();
                            cachedData.UpdateTokenCache(getIdentityToken.AccessToken, getRefreshTokenDetails.UserId + ":" + DateTime.UtcNow.AddMinutes(tokenExpiration).ToFormateDateTimeString());
    
                            var getUserDetails = userBl.GetUserDetails(getRefreshToken.UserId);
                            getUserDetails.DeviceId = getRefreshTokenDetails.DeviceId;
                            getUserDetails.DeviceType = getRefreshTokenDetails.DeviceType;
                            getUserDetails.AccessToken = getIdentityToken.AccessToken;
                            getUserDetails.TokenType = "bearer";
                            getUserDetails.ExpiresIn = getIdentityToken.ExpiresIn;
                            getUserDetails.Issued = getIdentityToken.Issued;
                            getUserDetails.Expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(tokenExpiration)).ToString("R");
                            getUserDetails.RefreshToken = getIdentityToken.RefreshToken;
    
    
    
                            //Dictionary<string, string> tokenResponse = new Dictionary<string, string>();
                            //tokenResponse.Add("access_token", getIdentityToken.AccessToken);
                            //tokenResponse.Add("token_type", "bearer");
                            //tokenResponse.Add("expires_in", getIdentityToken.ExpiresIn);
                            //tokenResponse.Add("issued", getIdentityToken.Issued);
                            //tokenResponse.Add("expires", DateTime.UtcNow.Add(TimeSpan.FromMinutes(tokenExpiration)).ToString("R"));
                            //tokenResponse.Add("refresh_token", getIdentityToken.RefreshToken);
                            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, getUserDetails));
                        }
                        else
                        {
                            apiResponse.Message = "Your session has expired. Kindly login again.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
    
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Gone, apiResponse));
            }
