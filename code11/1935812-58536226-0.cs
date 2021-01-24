public async Task<string> CheckDevice(string id)
        {
            var uri = new Uri(string.Format(Constant.CheckDevicesRegistration + "id=" + id, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var jsonData = (JObject)JsonConvert.DeserializeObject(result);
                    var message = jsonData["response"]["message"].Value<string>();
                    resultService = message;
                }
            }
            catch
            {
                resultService = "Connection-Error";
            }
            return resultService;
        }
