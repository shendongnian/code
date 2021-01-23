	class TweetSetting
	{
		public int MinReferenceCount { get; protected set; }
		public string ViewName { get; protected set; }
		
		public TweetSetting(int minReferenceCount, string viewName)
		{
			MinReferenceCount = minReferenceCount;
			ViewName = viewName;
		}
	}
	…
	var settings =
		new[]
		{
			new TweetSetting(13, "Tweet"),
			new TweetSetting(16, "TShirt"),
			new TweetSetting(17, "Banner"),
			new TweetSetting(22, "Tweet")
		};
	
	var referenceCount = …; // whatever
	
	foreach (var setting in settings)
	{
		if (referenceCount <= setting.MinReferenceCount)
			break;
		
		Html.RenderPartial(setting.ViewName, Model.tweets.FirstOrDefault());
	}
