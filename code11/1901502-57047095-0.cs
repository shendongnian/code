    public static async Task<IEnumerable<T>> GetDataFromAPIAsync<T>(string controllerURI)
    {
        HttpClientHandler handler = new HttpClientHandler();
        HttpClient client = new HttpClient(handler);
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        try
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:50000" + controllerURI);
            response.EnsureSuccessStatusCode();
            string apiResponse = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<T>>(apiResponse);
            return list;
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine(ex.InnerException);
            return list;
        }
        finally
        {
            handler.Dispose();
            client.Dispose();
        }
    }
