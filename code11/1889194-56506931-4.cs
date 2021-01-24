        private async Task<T> FetchJsonResult<T>(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode)
            {
                // Convert the HttpResponseMessage to string
                var resultArray = await result.Content.ReadAsStringAsync();
                // Json.Net Deserialization
                var final = JsonConvert.DeserializeObject<T>(resultArray);
                return final;
            }
            else
            {
                // Handle Error Return Null
            }
        }
