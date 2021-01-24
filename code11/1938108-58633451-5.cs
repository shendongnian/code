     HttpClient client = new HttpClient();  
    
    public async Task PostAsync(string actionName, object json)
    {
            var content = new StringContent(json.ToString(), Encoding.UTF8,"application/json");
            var resultRoles = await client.PostAsync(new Uri(actionName),content);
    }
           
