            var authority = $"https://login.microsoftonline.com/{tenantId}/v2.0";
            List<string> scopes = new List<string>();
            scopes.Add("https://graph.microsoft.com/.default");
            var cca = ConfidentialClientApplicationBuilder.Create(AppID)
                                                    .WithAuthority(authority)
                                                    .WithRedirectUri(RedirectURI)
                                                    .WithClientSecret(APPKey)
                                                    .Build();
            return new MsalAuthenticationProvider(cca, scopes.ToArray());
        }
        public static HttpClient GetAuthenticatedHTTPClient()
        {
            var authenticationProvider = CreateAuthorizationProvider();
            _httpClient = new HttpClient(new AuthHandler(authenticationProvider, new HttpClientHandler()));
            return _httpClient;
        }
