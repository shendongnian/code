string Seshat_URL = "https://azr-stg.dev03.abs.ase.southcentralus.us.wc.net/files/v11";
      using (var multiPartStream = new MultipartFormDataContent())
                {
                    multiPartStream.Add(new StringContent("{}"), "metadata");
                    multiPartStream.Add(new ByteArrayContent(filecontent, 0, filecontent.Length), "file", docName);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Seshat_URL);
                    request.Content = multiPartStream;
                    //"application/json" - content type
                    request.Headers.Accept.Add(JSON_GENERIC_MEDIA_TYPE);  
                    request.Headers.Add("X-Client-Id", ClientId);                
                    request.Headers.Add("Tenant-Id", TenantId);
                                     
                    HttpCompletionOption option = HttpCompletionOption.ResponseContentRead;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                    using (HttpResponseMessage response = _httpClient.SendAsync(request, option).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var deserializedObject = JsonConvert.DeserializeObject<Wc.MCM.UIMVC.Helpers1.BlobResponse>(response.Content.ReadAsStringAsync().Result);
                            return deserializedObject.fileId.ToString();
                        }                        
                    }
                }//End Try
