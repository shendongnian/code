    public static void Main()
    {
		var client = new WebClient();
		
		client.GetRssDownloadTask(
            new Uri("http://blogs.msdn.com/b/ericlippert/rss.aspx"))
			.ContinueWith( t => {
				ShowXmlInMyUI(t.Result); // show first result somewhere
				// start a new task here if you want a chain sequence
			});
			
		// or start it here if you want to get some rss feeds simultaneously
		
        // if we had await now, we would add 
        // async keyword to Main method defenition and then
	
		XDocument feedEric = await client.GetRssDownloadTask(
            new Uri("http://blogs.msdn.com/b/ericlippert/rss.aspx"));
		XDocument feedJon = await client.GetRssDownloadTask(
            new Uri("http://feeds.feedburner.com/JonSkeetCodingBlog?format=xml"));
        // it's chaining - one task starts executing after 
        // another, but it is still asynchronous
    }
