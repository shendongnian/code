    public async Task<List<TideRoot>> GetTideInfo(string id, string duration)
        {
            using (var client = new HttpClient())
            {
                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "223604c97163487bb857cfb554c96c90");
                var url = string.Format(TideInfo, id, duration);
                var json = await client.GetStringAsync(url);
                if (string.IsNullOrWhiteSpace(json))
                    return null;
                //deserialize the array into a list of Result objects, and take the object at index zero.
                var result = JsonConvert.DeserializeObject<List<TideRoot>>(json);
                return result;
            }
        }
           
      //in model
      List<TideRoot> tidelist;
      public List<TideRoot> TideList
      {
          get { return tidelist; }
          set { tidelist = value; OnPropertyChanged(); }
      }
      TideList = await WeatherService.GetTideInfo("0065", "7");
      //xaml
      <ListView ItemsSource="{Binding TideList}"
