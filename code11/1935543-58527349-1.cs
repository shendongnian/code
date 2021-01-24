     public async Task<ActionResult> Index()
            {
                Currency CurencyInfo = new Currency();
    
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
    
                    client.DefaultRequestHeaders.Clear();
    
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Uri myUri = new Uri("https://api.exchangeratesapi.io/latest", UriKind.Absolute);
    
                    HttpResponseMessage Result = await client.GetAsync(myUri);
    
                    if (Result.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var CurrencyResponse = Result.Content.ReadAsStringAsync().Result;
    
    
                        //Deserializing the response recieved from web api and storing into the CurrencyInfo 
                        CurencyInfo = JsonConvert.DeserializeObject<Currency>((JObject.Parse(CurrencyResponse)).ToString());
    
                    }
    
                    //returning the Currency Info to view  
                    return View(CurencyInfo);
                }
    
            }
