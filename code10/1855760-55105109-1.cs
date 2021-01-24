    string apiUrl = "http://localhost:12408/api/Studentst";
                using (HttpClient client=new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new 
    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var student = 
    Newtonsoft.Json.JsonConvert.DeserializeObject<[QualifiedNamespace].Student>(data);
                }
            }
