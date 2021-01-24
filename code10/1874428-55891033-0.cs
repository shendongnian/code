    async void Main()
    {
    	// ...
    	
    	string BuildUrl(string summonerName) => $@"https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}apikeyiswhatgoesintherestofthispartoftheapi";
    	
    	foreach (var item in matchlistd)
    	{
    		var response2 = await client.GetAsync(BuildUrl(item.summonerName));
    	    if (response2.IsSuccessStatusCode)
    	    {
    			var content2 = await response2.Content.ReadAsStringAsync();
    	        summonerName player = JsonConvert.DeserializeObject<summonerName>(content2);
    	        accountinfo.Add(player);
    	    }
    	}
    	// ...
    }
