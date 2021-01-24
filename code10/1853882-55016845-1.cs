    client.DefaultRequestHeaders.Add("authKey", authKey);
    var json = JsonConvert.SerializeObject(product, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    var content = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PutAsync(url, content);
    if (response.IsSuccessStatusCode)
    {
        
    }
    else
    {
        var result = response.Content.ReadAsStringAsync().Result;
        throw new Exception("Error Occured in Update Product" + result);
    }
