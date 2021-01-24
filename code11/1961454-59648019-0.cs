	// create a dictionary to hold the categories:
	
	var categories = new Dictionary<int, string>
	{
		{ 2403, "Foo" },
		{ 2404, "Bar" }
	};
	foreach(XNode node in doc.DescendantNodes())
	{
		if(node is XElement)
		{
			XElement element = (XElement)node;
			if (element.Name.LocalName.Equals("category"))
			{
			
				var ids = element.Value;
				
				// Split the comma-separated integers, parse them and store them in a list
				var idList = ids.Split(',').Select(int.Parse).ToList();
				
				// Translate the IDs to the appropriate strings
				var categoryNames = idList.Select(i => categories[i]).ToList();
				
				// Concatenate the category names into a single string again
				var concatenated = string.Join(",", categories);
				
				// And assign it to the value again
				element.Value = concatenated;				
			}
		}
