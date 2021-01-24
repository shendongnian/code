    	private readonly ITwitterApiClient _twitterApiClient;
    
    	public TweetController(ITwitterApiClient twitterApiClient)
    	{
    		_twitterApiClient = twitterApiClient;
    	}
    	
    	[HttpGet]
    	public async Task<IEnumerable<string>> Get()
    	{
    		return await _twitterApiClient.GetTweets();
    	}
    }
