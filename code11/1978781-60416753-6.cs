    private async Task<string> HttpRequest()
        {
            //Your Request End Point
            string requestUrl = $"http://10.10.102.109/api/v1/routing/windows/Window1";
            var requestContent = new HttpRequestMessage(HttpMethod.Post, requestUrl);
    
            //Request Body in Key Value Pair
            requestContent.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["CanYCentre"] = "540",
                ["CanXCentre"] = "960",
            });
            requestContent.Headers.Add("Authorization", "Basic" + "YourAuthKey");
            HttpClient client = new HttpClient();
            //Sending request to endpoint
            var tokenResponse = await client.SendAsync(requestContent);
            //Receiving Response
            dynamic json = await tokenResponse.Content.ReadAsStringAsync();
            dynamic response = JsonConvert.DeserializeObject<dynamic>(json);
    
            return response;
        }
