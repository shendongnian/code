    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.Net.Http;
    using TestFunction.Models;
    using System.Net;
    using System.Text;
   
    
    namespace HaithemKAROUIApiCase.Functions
    {
        public static class HaithemKAROUIApiCaseClass
        {
            [FunctionName("HaithemKAROUIApiCaseFunction")]
            public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
    
                try
                {
                    // Convert all request param into Json object
    
                    var content = req.Content;
                    string jsonContent = content.ReadAsStringAsync().Result;
                    dynamic requestPram = JsonConvert.DeserializeObject<PartnerMpnModel>(jsonContent);
    
    
                    // Extract each param
                    //string mpnId = requestPram.mpnId;
    
                    if (string.IsNullOrEmpty(requestPram.MpnID))
                    {
                        return req.CreateResponse(HttpStatusCode.OK, "Please enter the valid partner Mpn Id!");
                    }
                    // Call Your  API
                    HttpClient newClient = new HttpClient();
                    HttpRequestMessage newRequest = new HttpRequestMessage(HttpMethod.Get, string.Format("YourAPIURL?mpnId={0}", requestPram.MpnID));
    
                    //Read Server Response
                    HttpResponseMessage response = await newClient.SendAsync(newRequest);
                    bool isValidMpn = await response.Content.ReadAsAsync<bool>();
    
    
                    //Return Mpn status 
                    return req.CreateResponse(HttpStatusCode.OK, new PartnerMpnResponseModel { isValidMpn = isValidMpn });
                }
                catch (Exception ex)
                {
    
                    return req.CreateResponse(HttpStatusCode.OK, "Invaild MPN Number! Reason: {0}", string.Format(ex.Message));
                }
            }
        }
    
 
       public class PartnerMpnModel
        {
            public string MpnID { get; set; }
        }
        public class PartnerMpnResponseModel
        {
            public bool isValidMpn { get; set; }
        }
    }
