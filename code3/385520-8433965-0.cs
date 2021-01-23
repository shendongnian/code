    		public class Review { }
    		public class BookReview : Review
    		{
    			public string PubDate;
    			public string Title;
    
    		}
    		public static void Main()
    		{
    			string xml = @"
    <FEED>
    <FEED_HEADER>
        <FEED_NAME>foo</FEED_NAME>
        <FEED_CODE>foobar123</FEED_CODE>
    </FEED_HEADER>
    <FEED_CONTENT>
        <DOC>
            <PUB_DATE>2011-12-01</PUB_DATE>
            <TITLE>Monkey Bombs</TITLE>
        </DOC>
        <DOC>
            <PUB_DATE>2011-12-10</PUB_DATE>
            <TITLE>A Silly Hat</TITLE>
        </DOC>
        <DOC>
            <PUB_DATE>2011-12-25</PUB_DATE>
            <TITLE>Wind Blows Up My Skirt</TITLE>
        </DOC>
    </FEED_CONTENT>
    </FEED>";	// NOTE: I closed  the <FEED> element!
    			var xmlDoc = XDocument.Parse(xml);
    			IEnumerable<BookReview> reviews = null;
    			try
    			{
    				reviews = from item in xmlDoc.Descendants("DOC")
    						  select new BookReview()
    						  {
    							  PubDate = item.Element("PUB_DATE").Value,
    							  Title = item.Element("TITLE").Value,
    						  };
    			}
    			catch (Exception ex)
    			{
    				//...
    			}
    
    			foreach (var review in reviews)
    			{
    				Console.WriteLine("{0}, {1}", review.PubDate, review.Title);
    			} 
    			var reviews2 = reviews.Cast<Review>().ToList();
    
    			Console.ReadLine();
    		}
