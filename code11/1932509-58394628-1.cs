    try
            {
                /*This is the Line I added and it makes my .NET Core API Accessible in my VSTO-AddIn  */
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string serviceUrl= "https://domainname/api/values";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(serviceUrl).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
