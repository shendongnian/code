    static void Main(string[] args)
        {
            //Data.xml
            /*
            <?xml version="1.0" encoding="UTF-8"?>
                <product>
                    <item>
		                <name>test</name>
	                </item>
                    <item>
		                <name>test2</name>
	                </item>
                    <item>
		                <name>test3</name>
	                </item>
                </product>
             */
            XDocument meteoDoc = XDocument.Load("data.xml");
            var result = from c in meteoDoc.Descendants("item")
                         select new { Name = c.Element("name").Value };
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
 
