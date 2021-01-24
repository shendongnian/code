    public async System.Threading.Tasks.Task<string> MyMethod(string studyInstanceUID)
    {
        using (var client = new HttpClient())
        {
    
            string data = "{\"Level\":\"Study\",\"Query\":{\"Modality\":\"MR\",\"StudyInstanceUID\":\"" + studyInstanceUID + "\"}}";
    
            var requestContent = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");
    
            client.DefaultRequestHeaders.Add("User-Agent", "Anything");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            if (reqAuth)
            {
                var byteArray = Encoding.ASCII.GetBytes(authString);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            }
    
            HttpResponseMessage response = await client.PostAsync(baseUrl + "tools/find", requestContent);
    
            var responseContent = response.Content;
    
            return responseContent.ReadAsStringAsync().Result;
        }
    
    }
