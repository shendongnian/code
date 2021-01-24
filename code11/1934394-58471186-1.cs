        public string UpdateMessageTemplate(string token, int clientId, int templateID, string template)
        {
            try
            {
               string serviceUrl =$"{ConfigurationManager.AppSettings["APIURL"]}/notification/updateMessageTemplate/{templateID}";
    
               HttpClient client = new HttpClient();
               StringContent content = new StringContent(template);
               client.DefaultRequestHeaders.Add("clientId", clientId.ToString());
               client.DefaultRequestHeaders.Add("Authorization", string.Format("bearer {0}", token));
               var response = client.PatchAsync(serviceUrl, content).Result;
               return response;
    
            }
            catch (Exception ex)
            {
               NameValueCollection logParams = new NameValueCollection();
               Logger.LogErrorEvent(ex, logParams);
               throw;
             }
        }
