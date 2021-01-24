        public class HttpHelperService
        {
                    public async Task<List<OfferModel>> AllOffers(string methodName)
                    {
                        List<OfferModel> result;
                        string responseBody;
                        using (HttpClient client = new HttpClient())
                        {
                            try
                            {
                                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Settings.AccessToken);
                                HttpResponseMessage response = client.GetStringAsync(new Uri(UrlConstants.offerurl)).GetAwaiter().GetResult();
                                result = JsonConvert.DeserializeObject<List<OfferModel>>(response);
                            }
                            catch (Exception ex)
                            {
                                result = null;
                            }
                            return result;
                        }
                    }
            }
        
        
