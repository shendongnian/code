    private Timer _functionTimer; 
    
    public void InitMatchList()
    {
        _functionTimer_Tick = new Timer();
        _functionTimer_Tick.Tick += new EventHandler(_functionTimer_Tick);
        _functionTimer_Tick.Interval = 50; // in miliseconds
        _functionTimer_Tick.Start();
    }
    
    private void _functionTimer_Tick(object sender, EventArgs e)
    {
        var response2 = client.GetAsync($@"https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{item.summonerName}apikeyiswhatgoesintherestofthispartoftheapi).Result;
        if (response2.IsSuccessStatusCode)
        {
            var content2 = response2.Content.ReadAsStringAsync().Result;
            summonerName player = JsonConvert.DeserializeObject<summonerName>(content2);
            accountinfo.Add(player);
        }
    }
