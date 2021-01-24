    List<int> data = new List<int>() // This is your array
    
    string JsonData = JsonConvert.SerializeObject(data);
    
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                
                HttpResponseMessage result = await client.PostAsync("your adress", content);
