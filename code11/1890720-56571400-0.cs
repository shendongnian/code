    if (response.IsSuccessStatusCode)
    {
        var byteArray = await response.Content.ReadAsByteArrayAsync();
        var content = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
        _result = JsonConvert.DeserializeObject<List<BomLookupModel>>(content);
    }
