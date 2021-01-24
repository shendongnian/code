    [HttpGet("[action]")]
        public async Task<List<FlightOffersModel>> GetData(string origin, string destination, string departureDate, string returnDate, string adults, string currency)
        {
            const string client_id = "oqsIlG0xAbnlXXXXXXXXXXg7GdYwemI5";
            const string client_secret = "lAcXXXXXXXXX5AD0";
            string token = await GetToken(client_id, client_secret);
            
            const string baseUrl = "https://test.api.amadeus.com/v1/";
            string urlParams = "shopping/flight-offers?origin=" + origin + "&destination=" + destination + "&departureDate=" + departureDate;
            urlParams += returnDate == "" || returnDate == null ? "" : "&returnDate=" + returnDate;
            urlParams += "&adults=" + adults + "&nonStop=false&currency=" + currency + "&max=50";
            FlightOffer ff = null;
            List<FlightOffersModel> model = new List<FlightOffersModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.amadeus+json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync(urlParams);
                if (response.IsSuccessStatusCode)
                {
                    var x = await response.Content.ReadAsStringAsync();
                    var xx = JObject.Parse(x);
                    ff = JsonConvert.DeserializeObject<FlightOffer>(xx.ToString());
                    
                    foreach (var fo in ff.Data)
                    {
                        FlightOffersModel temp = new FlightOffersModel();
                        foreach (var item in fo.OfferItems)
                        {
                            foreach (var service in item.Services)
                            {
                                if (item.Services.IndexOf(service) < 1)
                                {
                                    temp.BrojPresjedanjaPovratak = item.Services.Length > 1 ? GetBrojPresjedanja(item.Services[1]) : 0;
                                    temp.BrojPresjedanjaOdlazak = GetBrojPresjedanja(item.Services[0]);
                                    temp.BrojPutnika = GetBrojPutnika(service.Segments);
                                    temp.UkupnaCijena = item.Price.Total;
                                    temp.Valuta = ff.Meta.Currency;
                                    temp.PolazniAerodrom = GetAerodromName(service.Segments, "departure", ff.Dictionaries.Locations);
                                    temp.OdredisniAerodrom = GetAerodromName(service.Segments, "arrival", ff.Dictionaries.Locations);
                                    temp.DatumPolaska = GetDatumLeta(service.Segments, "departure");
                                    temp.DatumPovratka = GetDatumLeta(service.Segments, "arrival");
                                    model.Add(temp);
                                }
                            }
                        }
                    }
                }
            }
            return model;
        }
