        private void TestApi()
        {
            try
            {
                     using (var httpClient = new HttpClient())
                    {
                        string URI = string.Empty;
                        string progressAPI = "api/GetNearBeacons";
                        var baseUrl = @"http://localhost/Beacon";
                        var uriBuilder = new UriBuilder(baseUrl)
                        {
                            Scheme = Uri.UriSchemeHttp
                        };
                        httpClient.BaseAddress = uriBuilder.Uri;
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = httpClient.GetAsync(progressAPI).Result;
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            WriteErrorLog("Api called successfully StatusCode :" + response.StatusCode + Environment.NewLine);
                        }
                        else
                        {
                            WriteErrorLog("Api Calling Failed StatusCode :" + response.StatusCode + Environment.NewLine);
                        }
                    }
                
            }
            catch (WebException ex)
            {
                WriteErrorLog(ex.GetBaseException().ToString());
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.GetBaseException().ToString());
            }
        }
