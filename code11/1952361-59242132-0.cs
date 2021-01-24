    public async Task<string> GetResponse(string page, Dictionary<string, string> args) {
        //assume page = "/user/login.json" and args == {"username", "user"},{"password", "pass"}
        try {
            QueryString queryString = QueryString.Create(args);
            var url = new Uri(page + queryString.ToString());
            var request =new HttpRequestMessage(HttpMethod.Get, url);        
            var response = await Client.SendAsync(request);
            if(response.IsSuccessStatusCode){
                return await response.Content.ReasStringAsync();
            return string.Empty;
        } catch { return string.Empty; }
    }
