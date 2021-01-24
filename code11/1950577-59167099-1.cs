    string[] groupFields = new[] { "AnalyteCode", "AnalyteName", "Result", "ResultText" };
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(input);
    
    int groupIndex = 0;
    List<LabResultItem> results = new List<LabResultItem>();
    LabResultItem currentItem = new LabResultItem();
    foreach (XmlNode node in doc.SelectSingleNode("/LabResults/LabResult/LabResultItems/LabResultItem").ChildNodes)
    {
    	if (node.Name == groupFields[groupIndex])
    	{
    		var propName = groupFields[groupIndex];
    		var prop = typeof(LabResultItem).GetProperty(propName);
    		if(prop == null)
    		{
    			throw new Exception($"Invalid property found in groupFields: '{propName}', property must be a part of {nameof(LabResultItem)}");
    		}
    		prop.SetValue(currentItem, node.InnerText, null);
    
    		// reset group index on wrap
    		if (++groupIndex >= groupFields.Length)
    		{
    			results.Add(currentItem);
    			currentItem = new LabResultItem();
    			groupIndex = 0;
    		}
    	}
    }
