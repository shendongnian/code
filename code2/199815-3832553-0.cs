    var dbAllData = Post.All();  //IQueryable
    
                UserTimelineOptions options = new UserTimelineOptions();
                options.ScreenName = "USERNAME";
                options.Count = 5000;
                options.IncludeRetweets = true;
    
                TwitterStatusCollection recentTweets = TwitterTimeline.UserTimeline(options);
    
    
                var dbAllMerged = dbAllData.AsEnumerable().Select((title) => new BlogData { Title = title.Title, Date = title.Date, RelativeDate = title.Date.ToRelativeDate(), Text = title.Text, DBRecord = true });
                dbAllMerged = dbAllMerged.Concat(recentTweets.Where(y => !y.Text.StartsWith("@")).Select((tweet) => new BlogData { Title = "", Date = tweet.CreatedDate, RelativeDate = tweet.CreatedDate.ToRelativeDate(), Text = tweet.Text, DBRecord = false })).OrderByDescending(x => x.Date);
