    public class AzureStatusController : ApiController
    {
        private static bool cloudStatus = false;
        private static DateTime expiration;
        /// <summary>
        /// Classes Ctor
        /// </summary>
        public AzureStatusController()
        {
            expiration = DateTime.Now.AddHours(-1);
        }
        private void CheckAzureStatus()
        {
            var status = false;
            using (var client = new HttpClient())
            {
                // the following 2 lines should be changed to retrieve the info from 
                var url = ConfigurationManager.AppSettings["CloudFunctionsBaseUrl"];
                var code = ConfigurationManager.AppSettings["CloudStatusCode"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync(code);
                    if (response != null && !response.IsFaulted)
                    {
                        var result = response.Result;
                        if (result != null && result.IsSuccessStatusCode && result.Content != null)
                        {
                            string responseString = result.Content.ReadAsStringAsync().Result.Trim().ToLower();
                            status = (responseString.Contains("ok"));
                        }
                    }
                }
                catch
                {
                    status = false;
                }
            }
            cloudStatus = status;
            expiration = DateTime.Now.AddMinutes(1);
        }
        /// <summary>
        /// Returns the cached value of the Azure status
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("api/AzureStatus")]
        public IHttpActionResult Get()
        {
            if (expiration < DateTime.Now)
            {
                CheckAzureStatus();
            }
            return Ok(cloudStatus);
        }
    }
