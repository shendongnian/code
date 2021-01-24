    public async Task<string> GetPartialResponseAsync(string url, int length)
    {
        var request = System.Net.WebRequest.Create(url);
        request.Method = "GET";
        using (var response = await request.GetResponseAsync())
        using (var responseStream = response.GetResponseStream())
        {
            byte[] buffer = new byte[length];
            await responseStream.ReadAsync(buffer, 0, length);
            return System.Text.Encoding.Default.GetString(buffer);
        }
    }
