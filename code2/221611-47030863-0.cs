    string username = "...";
    string password = "...";
    
    public IRestResponse GetResponse(string url, Method method = Method.GET)
    {
    	string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}:{password}"));
    	var client = new RestClient(url);
    	var request = new RestRequest(method );
    	request.AddHeader("Authorization", $"Basic {encoded}");
    	IRestResponse response = client.Execute(request);
    	return response;
    }
    
    var response = GetResponse("...");
    txtResult.Text = response.Content;
