    public class TwitterManager
    {
        private readonly ITwitterCredentials _credentials;
        private bool _isRateLimited;
        public TwitterManager()
        {
            _credentials = Auth.SetUserCredentials("", "", "", "");
            TweetinviEvents.QueryBeforeExecute += (sender, args) =>
            {
                var queryRateLimit = RateLimit.GetQueryRateLimit(args.QueryURL);
                if (queryRateLimit != null)
                {
                    if (queryRateLimit.Remaining > 0)
                         return;
                    else
                        _isRateLimited = true;
                }
            };
        }
        public void GetTweets() {
            UserTimelineParameters userTimelineParameters = new UserTimelineParameters();
            userTimelineParameters.MaximumNumberOfTweetsToRetrieve = 50;
            try
            {
                var tweets = Auth.ExecuteOperationWithCredentials(_credentials, () =>
                {
                    return Timeline.GetUserTimeline("cnn", userTimelineParameters);
                });
                if (_isRateLimited)
                {
                    Console.WriteLine("Request rate limit has been exceeded. Please try again later.");
                }
                else if (tweets != null) {
                    foreach (var item in tweets)
                    {
                        Console.WriteLine(item.FullText);
                    }
                }
                Console.ReadKey();
            }
            catch (WebException wex)
            {
                var statusCode = -1;
                if (statusCode == TweetinviConsts.STATUS_CODE_TOO_MANY_REQUEST)
                {
                    // The RateLimit is exhausted. Perform your code to manage it!
                }
            }
        }
    }
