    public async Task<string> GetResponse(string page, Dictionary<string, string> args) {
        //assume page = "/user/login.json" and args == {"username", "user"},{"password", "pass"}
        try {
            QueryString queryString = QueryString.Create(args);
            var uri = new Uri(page + queryString.ToString());
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await Client.SendAsync(request);
            if(response.IsSuccessStatusCode){
                return await response.Content.ReadAsStringAsync();
            return string.Empty;
        } catch { return string.Empty; }
    }
