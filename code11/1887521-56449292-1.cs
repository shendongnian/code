    public static async Task<string> ExecCmd(string name, string url, string token)
    {
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        string result = await GetHttpContentWithToken(url, token);
        JObject json = JsonConvert.DeserializeObject(result) as JObject;
        File.WriteAllText(name, json.ToString());
        return result;
    }
