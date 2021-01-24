    [HttpPost]
        public async Task<string> SaveData()
        {
           //Since the API will need the new data in JSON format 
           //therefore I am serializing the data into JSON and then converting it to a StringContent object
           StringContent content=new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json" );
    
           //The StringContent object is then added to the API request by adding it to the 2nd parameter of the PostAsync() method.
           var response = await _client.PostAsync(path ,content);
           var content= response.Content.ReadAsStringAsync().Result;
            return "OK";
        }
