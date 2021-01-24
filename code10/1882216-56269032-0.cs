    using (HttpClient client = new HttpClient())
    {
        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
            var content = new ByteArrayContent(File.ReadAllBytes(fileAddress));
            HttpResponseMessage response = client.PutAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                //response is empty. Have to call the checkAssetStatus to see if the asset is 'AVAILABLE'
                string responseBody = response.Content.ReadAsStringAsync().Result;
                        
            }
            else
            {
                //handleError();
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", ex.Message);
        }
    }
