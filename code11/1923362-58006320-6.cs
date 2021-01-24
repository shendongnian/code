    using (var client = new HttpClient()){ 
       HttpResponseMessage response = await client.GetAsync(requestUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                    string content = await response.Content.ReadAsStringAsync();
                    Grab grab = JsonConvert.DeserializeObject<Grab>(content);
                    List<Grab.Date> dates = grab.PS4_Beta;
                    foreach (var item in dates)
                    {
                        Log.Error("Firmware", "==" + item.Firmware);
                    }
            }
