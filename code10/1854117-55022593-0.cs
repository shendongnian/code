    public async void SendUserDataToServer()
    {
    	user user = new user();
    	{
    		user.firstname = "aaaa";
    		user.secondname = "aaaaaaaaaaa";
    		user.email = "aaa";
    		user.phonenumber = "aaa";
    	};
    	string json = JsonConvert.SerializeObject(user);
    	using (var client = new HttpClient())
    	{
    		var response = await client.PostAsync(
    			"https://scs.agsigns.co.uk/test.php", 
    			 new StringContent(json, Encoding.UTF8, "application/json"));
    	}
    	DisplayAlert("Alert", json, "OK");
    }
