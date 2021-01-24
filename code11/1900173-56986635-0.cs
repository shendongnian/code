    using (var client = new HttpClient())
                {
                    string url = "http://localhost:7936";
                    client.BaseAddress = new Uri(url);
                    var jsonString = JsonConvert.SerializeObject(contentValue);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("/Api/Logger/PostActionLog", content);
                    string resultContent = await result.Content.ReadAsStringAsync();                
                }
