        #region UpdateUserOpportunityWon
        public async Task<string> UpdateUserOpportunityWon(string bearerToken, string opportunityid, string wonsubject, string actualend = "", int actualrevenue = 0, string wondesc = "")
        {
            string jResu = "";
            try
            {
                string opportunitiesURL = string.Format(GenericMethods.GetAppSetting("UpdateCRMOpportunityAPI"), opportunityid);
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string jsonBody = "";
                if (String.IsNullOrEmpty(actualend))
                {
                    jsonBody = "{'Status':3,'OpportunityClose':{'subject':'" + wonsubject + "','actualrevenue':" + actualrevenue + ",'description':'" + wondesc + "','opportunityid@odata.bind':'" + opportunitiesURL + "'}}";
                }
                else
                {
                    jsonBody = "{'Status':3,'OpportunityClose':{'subject':'" + wonsubject + "','actualrevenue':" + actualrevenue + ",'actualend':'" + actualend + "','description':'" + wondesc + "','opportunityid@odata.bind':'" + opportunitiesURL + "'}}";
                }
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                string opportunitiesWonURL = string.Format(GenericMethods.GetAppSetting("UpdateOpportunityWon"), opportunityid);
                var result = httpClient.PostAsync(opportunitiesWonURL, content).Result;
              //  TelemetryHelper.Trace("API res", result.ToString());
                string statuscode = result.StatusCode.ToString();
                if (result != null)
                {
                    var opporJSON = await result.Content.ReadAsStringAsync();
                    if (statuscode.ToLower() == "nocontent")
                    {
                        jResu = statuscode; //success
                    }
                    else
                    {
                        JToken jsonResult = JsonConvert.DeserializeObject<JObject>(opporJSON);
                        if (jsonResult["error"] != null)
                        {
                            jResu = jsonResult["error"]["message"].ToString();
                        }
                    }
                }
                else
                {
                    jResu = Resources.CommonAPIError + statuscode;
                }
            }
            catch (Exception ex)
            {
                TelemetryHelper.Trace("API Ex", ex.Message.ToString());
            }
            return jResu;
        }
        #endregion
