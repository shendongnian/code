    li.Text = tweet.text;
    foreach(Twitterizer.Entities.TwitterEntity te in tweet.Entities)
    {
        if(te.GetType() == (typeof(Twitterizer.Entities.TwitterMediaEntity)))
        {
            var b = (Twitterizer.Entities.TwitterMediaEntity) te;
            li.Text += "<img src=\"" + b.MediaUrl + "\" />";
        }
    }
