        public async Task<string> SendPOST()
                {
                    var dict = new Dictionary<string, string>();
                    dict.Add("DNT", "1");
                    dict.Add("someformdata","MSCnE.Automation");
                    using (var formdata = new System.Net.Http.FormUrlEncodedContent(dict))
                    {
                        //do not use using HttpClient() - https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient
                        using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())    
                        {
                            formdata.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                            formdata.Headers.ContentType.CharSet = "UTF-8";
                            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:68.0) Gecko/20100101 Firefox/68.0");
                            using (var response = await httpClient.PostAsync("https://sts-service.mycompany.com/UPNFromUserName", formdata))
                            {
                                if (response.IsSuccessStatusCode)
                                {
                                    var postresult = await response.Content.ReadAsStringAsync();
                                    return postresult;
                                }
                                else
                                {
                                    string errorresult = await response.Content.ReadAsStringAsync();
                                    return errorresult;
                                }
                            }
                        }
                    }
                }
