	using System;
	using System.ServiceModel.Syndication;
	using System.Xml;
	
	public class MyClass
	{
		private static DateTime _lastFeedTime = new DateTime(2011, 10, 10);
		
		public static void Main()
		{
			XmlReader reader = XmlReader.Create("http://www.extremetech.com/feed");
			SyndicationFeed feed = SyndicationFeed.Load(reader);
			
			if (feed.LastUpdatedTime.LocalDateTime > _lastFeedTime)
			{
				_lastFeedTime = feed.LastUpdatedTime.LocalDateTime;
				
				// load feed...
			}
		}
	}
