    	Task<List<string>> GetTweets();
    }
    
    public class TwitterApiClient : ITwitterApiClient
    {
            public async Task<List<string>> GetTweets()
            {
                using (HttpClient client = new HttpClient())
                {
                    //Blah blah do everything here I want to do. 
                    //var result = await client.GetAsync("/tweets");
    
                    return new List<string> { "Tweet tweet" };
                }
            }
    }
    
