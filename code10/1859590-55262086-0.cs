    public async Task<string> GetLongLatAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://api.postcodes.io/postcodes/" + this._postcode);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _response = await client.GetAsync(client.BaseAddress);
            string result = null;
            if (_response.IsSuccessStatusCode)
            {
                //cast result into model and then set long/lat properties which can then be used in the UI
                result = await _response.Content.ReadAsStringAsync();
                rootObject = JsonConvert.DeserializeObject<RootObject>(_result);
                Longitude = Double.Parse(rootObject.result.longitude.ToString());
                Latitude = Double.Parse(rootObject.result.latitude.ToString());
            }
            return result;
        }
    }
