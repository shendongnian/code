        public async Task<List<YourJsonData>> GetJsonAsync(CancellationToken  cancellationToken = default)
        {
            using (var client = new HttpClient())
            {
                //Make the request, and ensure we can reach it
                var response = await client.GetAsync(yourJosnUrl, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    //Read the actual stream (download the content)
                    var content = await response.Content.ReadAsStringAsync();
                    //Make sure we do have some valid content before we try to deserialize it
                    if (string.IsNullOrEmpty(content))
                    {
                        return new List<YourJsonData>();
                    }
                    //Deserialize into a list of yourjsondata
                    return JsonConvert.DeserializeObject<List<YourJsonData>>(content);
                }
            }
            return new List<YourJsonData>();
        }
