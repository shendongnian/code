	using (var reader = XmlReader.Create(urle))
	{
		var feeds = SyndicationFeed.Load(reader);
		var serializer = new XmlSerializer(typeof(MediaGroup));
		foreach (SyndicationItem item in feeds.Items)
		{
			string subject = item.Title.Text;
			Console.WriteLine("subject: " + subject);
			
			var mediaGroup = item.ElementExtensions
				.ReadElementExtensions<MediaGroup>("group", "http://search.yahoo.com/mrss/", serializer)
				.FirstOrDefault();
			if (mediaGroup != null)
			{
				foreach (var mediaItem in mediaGroup.Items)
				{
					Console.WriteLine(mediaItem.Url);
				}
			}                    
		}
	}
