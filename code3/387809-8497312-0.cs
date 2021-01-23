    		public static void Main(string[] args)
    		{
    			string xml = @"
    <rss version='2.0'>
        <item>
            <date>01/01</date>
            <word>aberrant</word>
            <def>straying from the right or normal way</def>
        </item>
    
        <item>
            <date>01/02</date>
            <word>Zeitgeist</word>
            <def>the spirit of the time.</def>
        </item>
    </rss>";
    			var xdoc = XDocument.Parse(xml);
    			var result = xdoc.Root.Elements("item")
    				.Select(itemElem => itemElem.Elements().ToDictionary(e => e.Name.LocalName, e => e.Value))
    				.ToList();
    
    		}
