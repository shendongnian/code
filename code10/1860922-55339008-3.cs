    public class MyPage : ContentPage
    {
    //Here is your page constructor
        public MyPage()
        {
           GetServices(); //--> call here without awaiter
        }
    }
    //Here is your awaiter method
        private async void GetServices()
        {
           LoadingPopupService.Show();
           var result = await HttpService.AllOffers();
            LoadingPopupService.Hide();
        }
    //Here is your service.
        public async Task<List<OfferModel>> AllOffers()
        {
            var httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Settings.AccessToken);
            var response = await httpclient.GetStringAsync(UrlConstants.offerurl);
            var data =JsonConvert.DeserializeObject<List<OfferModel(response);
            return data;
        }  
   
