    XDocument XDocument = XDocument.Parse(MyXmlFile);
    		var grouped = XDocument.Descendants("P").GroupBy(x => x.Value).Where(g => g.Count() > 1);
    		foreach (var groupItem in grouped)
    		{
    			foreach (var item in groupItem)
    			{
    				Console.WriteLine(item);
    			}
    		}
