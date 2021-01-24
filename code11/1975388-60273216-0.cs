       public async void GetJSON()
        {
            var response = await client.GetAsync("REPLACE YOUR JSON URL");
            string stringJson = await response.Content.ReadAsStringAsync();
            urls= JsonConvert.DeserializeObject<List<imageurl>>(stringJson);
        }
