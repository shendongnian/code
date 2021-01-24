using (var context = new ClientContext("SiteURL"))
                {                   
                    context.ExecutingWebRequest += Context_ExecutingWebRequest;
}
public void Context_ExecutingWebRequest(object sender, WebRequestEventArgs e)
        {
            e.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + GetAccessToken();
        }
 public string GetAccessToken()
        {
            try
            {
                #region Get Access token for Azure AD access              
                var client = new RestClient("https://accounts.accesscontrol.windows.net/" + TenantID + "/tokens/OAuth/2");
                var request = new RestRequest(Method.POST);                
                request.AddParameter("grant_type", "client_credentials");
                request.AddParameter("client_id", "ClientID@TenantID");
                request.AddParameter("client_secret", "ClientSecret");
                request.AddParameter("resource", "00000003-0000-0ff1-ce00-000000000000/SharePointSite@TenantID");
                IRestResponse restClientResponse = client.Execute(request);
                var DeserializeObject = JsonConvert.DeserializeObject<BearerToken>(restClientResponse.Content.ToString());
                string accessToken = DeserializeObject.AccessToken;
                #endregion           
             
                return accessToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
