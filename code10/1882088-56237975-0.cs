     using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppUserContext.Token);
                    client.DefaultRequestHeaders.Add("x-language", "ar");
                    using (var stream = pf.InputStream)
                    {
                        var content = new MultipartFormDataContent();
                        var file_content = new ByteArrayContent(new StreamContent(stream).ReadAsByteArrayAsync().Result);
                        file_content.Headers.ContentType = new MediaTypeHeaderValue(pf.ContentType);
                        file_content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            FileName = JsonConvert.SerializeObject(pf.FileName),
                            
                        };
                        content.Add(file_content);
                        var url = "URL Here";
                        var response = client.PostAsync(url, content).Result;
                        response.EnsureSuccessStatusCode();
                    }
                }
