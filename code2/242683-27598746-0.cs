    public virtual TwitterStatus DeleteTweet(DeleteTweetOptions options)
    {
    	var id = options.Id;
    	var trim_user = options.TrimUser;
    			
    	return WithHammock<TwitterStatus>(WebMethod.Post, "statuses/destroy/{id}", FormatAsString, "?id=", id, "&trim_user=", trim_user);
    }
