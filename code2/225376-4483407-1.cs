    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using LinqToTwitter;
    using LinqToTwitter.Common;
    
    namespace TwitterConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Console.WriteLine("Here We go .. ");
    
                var twitterCtx = new TwitterContext();
    
                var publicTweets =
                    from tweet in twitterCtx.Status
                    where tweet.Type == StatusType.Public
                    select tweet;
    
                publicTweets.ToList().ForEach(
                    tweet => Console.WriteLine(
                        "User Name: {0}, Tweet: {1}",
                        tweet.User.Name,
                        tweet.Text));
    
                Console.WriteLine("Press2Exit");
                Console.ReadKey();
            }
        }
    }
