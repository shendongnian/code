    for(int pagina=1; pagina<=10; pagina++)
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.Timeout = TimeSpan.FromMinutes(30);
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    
                    var uri = string.Format(@"{0}pageSize={1}&page={2}", Constants.REQUEST_ENDPOINT, 15000,pagina);//Constants.MAXVALUE); 
    uri = uri + "&advancedFilter=__Status__~eq~'Active'";
    uri = uri + @"&dynamicColumns=Name,ID,Date,Status,Version,Name,Division";
    
                    uri = uri + "&orderDirection=DESC";
    
                    HttpResponseMessage response = await httpClient.GetAsync(uri);
    
    
                    if (response == null)
                    {
                        throw new Exception("There is no returned request from TAP API");
    
                    }
    
                    if (response.IsSuccessStatusCode)
                    {
                        var responseAsString = await response.Content.ReadAsStringAsync();
                        itemsCollection = JsonConvert.DeserializeObject<ItemsDto>(responseAsString) ?? new ItemsDto();
                        itemsCollectionTotal.Add(itemsCollection);
                    }
                    else
                    {
                        throw new Exception("An error request has ocurred: " + response.RequestMessage);
                    }
    
                    if (itemsCollection.Items == null)
                    {
                        log.Info("There is no documents available from API");
                        itemsCollection.Items = new List<Document>();
                    }
    
                }
    
                return itemsCollectionTotal;//itemsCollectionTotal.Item;
    
            }
