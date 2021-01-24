     public async static Task<List<ContentElement>> GetContent(int siteId)
            {
                var contentElements = new List<ContentElement>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalValues.APIUri);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    AddAuthenticationHeader(client);
                    var result =await client.GetAsync("api/Content/GetContent/" + (object)siteId);
                    if (result.IsSuccessStatusCode)
                    {
                        contentElements.AddRange((IEnumerable<ContentElement>)result.Content.ReadAsStringAsync<List<ContentElement>>());
                    }
                }
                return contentElements;
            }
