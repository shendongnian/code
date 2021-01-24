     HttpClient client = new HttpClient();
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    client.DefaultRequestHeaders.Clear();         
    
                    ByteArrayContent bytes = new ByteArrayContent(imageStream);
                    form.Add(bytes, "files", imageName);
                    form.Add(new StringContent("En"), "watermark");
                    form.Add(new StringContent("listing"), "type");
    
    
                    HttpResponseMessage response = await client.PostAsync("https://upload.*****.com/api/upload/photos", form);
                    var k = response.Content.ReadAsStringAsync().Result;
    
                    _Result = JsonConvert.DeserializeObject<List<Output>>(k);
