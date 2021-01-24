        /// <summary>
        /// Gets the Salesforce access token given the client_id, secret, username and password.
        /// </summary>
        /// <param name="log">Tracewriter log</param>
        /// <param name="_settings">ISalesforceConfigSettings _settings</param>
        /// <returns>A Salesforce access token</returns>
        private async string GetSalesforceAccessToken(TraceWriter log, ISalesforceConfigSettings _settings)
        {
            var httpClient = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12;
            // Create Request Body
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", _settings.SalesforceClientId),
                new KeyValuePair<string, string>("client_secret", _settings.SalesforceClientSecret),
                new KeyValuePair<string, string>("username", _settings.SalesforceUserName),
                new KeyValuePair<string, string>("password", _settings.SalesforcePassword),
                new KeyValuePair<string, string>("grant_type", _settings.SalesforceGrantType)
            });
            try
            {
                // Call to get access token
                var loginResponse = await httpClient.PostAsync(_settings.SalesforceLoginUrl, formContent);
                var loginResponseString = await loginResponse.Content.ReadAsStringAsync();
                // Log Login Response
                log.Info(loginResponseString);
                // Extract Access Token
               return JsonConvert
                    .DeserializeObject<SalesforceLoginResponse>(loginResponseString)
                    .AccessToken;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }
