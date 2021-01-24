    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using System.Net.Http.Headers;
    using System.Net;
    using System.Net.Http;
    using System.Collections.Generic;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    
    namespace ManageAS
    {
        public class ManageAS
        {
            string accessToken = null;
            string responseString = null;
            string serverStatus = null;
            string serverFullURI = Environment.GetEnvironmentVariable("FULL_SERVER_URI");
            static string shortServerName = Environment.GetEnvironmentVariable("SHORT_SERVER_NAME");
            string resourceURI = "https://management.core.windows.net/";
            string clientID = Environment.GetEnvironmentVariable("CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
            string tenantID = Environment.GetEnvironmentVariable("TENANT_ID");
            static string resourceGroupName = Environment.GetEnvironmentVariable("RESOURCE_GROUP_NAME");
            static string subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID");
            static Uri apiURI = null;
    
            [FunctionName("PerformAction")]
            public async Task<HttpResponseMessage> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
                ILogger log)
            {    
                await GetAccessToken();
                await GetServerStatus(accessToken);
    
                if (serverStatus == "Paused")
                {
                    apiURI = new Uri(string.Format("https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.AnalysisServices/servers/{2}/resume?api-version=2017-08-01", subscriptionId, resourceGroupName, shortServerName));
                    this.responseString = await ServerManagement(apiURI, accessToken);
                }
                if (serverStatus == "Succeeded")
                {
                    apiURI = new Uri(string.Format("https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.AnalysisServices/servers/{2}/suspend?api-version=2017-08-01", subscriptionId, resourceGroupName, shortServerName));
                    this.responseString = await ServerManagement(apiURI, accessToken);
                }
    
                return req.CreateResponse(HttpStatusCode.OK, responseString);
            }
    
            protected async Task<string> GetAccessToken()
            {
                string authority = "https://login.microsoftonline.com/" + tenantID;
                AuthenticationContext authenticationContext = new AuthenticationContext(authority);
                var token = await authenticationContext.AcquireTokenAsync(resourceURI, new ClientCredential(clientID, clientSecret));
                accessToken = token.AccessToken;
                return accessToken;
            }
    
            protected async Task<string> ServerManagement(Uri url, string token)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    
                HttpResponseMessage response = await client.PostAsync(url.ToString(), null);
                response.EnsureSuccessStatusCode();
                HttpContent content = response.Content;
    
                string json;
                json = await content.ReadAsStringAsync();
                return json;
            }
    
            protected async Task<string> GetServerStatus(string token)
            {
                var url = new Uri(string.Format("https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.AnalysisServices/servers/{2}?api-version=2017-08-01", subscriptionId, resourceGroupName, shortServerName));
    
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync(url.ToString());
    
                response.EnsureSuccessStatusCode();
                string sJson = await response.Content.ReadAsStringAsync();
                var dictResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(sJson);
                if (!dictResult.ContainsKey("properties")) return null;
                var dictProperties = dictResult["properties"] as Newtonsoft.Json.Linq.JObject;
                if (dictProperties == null || !dictProperties.ContainsKey("state")) return null;
                serverStatus = Convert.ToString(dictProperties["state"]);
                return serverStatus;
            }
        }
    }
