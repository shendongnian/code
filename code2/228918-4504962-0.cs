    using TweetSharp.Twitter.Fluent;
    using TweetSharp.Twitter.Model;
    using TweetSharp.Twitter.Extensions;
    
    
    //...
    
    var twitter = FluentTwitter.CreateRequest();
    twitter.Authentication.GetRequestToken("...", "...");
