    using (var client = new HttpClient()){ 
       HttpResponseMessage response = await client.GetAsync(requestUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                Grab myDates = JsonConvert.DeserializeObject<Grab >(content);
            }
