    var rowsList = new List<SoapRow>();
    var fieldsList = new List<SoapField>(); 
    //use XDocument instead of xmlDocument it's simpler and works very well with LINQ.
    var doc = XDocument.Parse(xml);
       
    // declare the namespace 
    var ns = doc.Root.GetNamespaceOfPrefix("soapenv");
    
    // get Body 
    var body = doc.Descendants(ns + "Body").Elements();
    
    // get MP0118_GetGridHeaderData_001_Result
    var gridresultheader = body.ElementAt(0).Elements();
    
    // get GRIDRESULT
    var gridresult = gridresultheader.ElementAt(0).Elements();
    
    // get GRID
    var grid = gridresult.ElementAt(0).Elements();
    
    // get DATA
    var rows = grid.ElementAt(0).Elements();
    
    // get FIELDS
    var fields = grid.ElementAt(1).Elements();
    
    // define the fields first
    foreach(var field in fields)
    {
    	fieldsList.Add(
    		new SoapField()
    		{
    			Aliasnum = field.Attribute("aliasnum").Value.Trim(), 
    			Name = field.Attribute("name").Value.Substring(4).Trim() //get the name without (ctr_)
    		}
    		);
    }
    
    // now loop over the rows, and map them to the fields.
    foreach (var row in rows)
    {
    	// get the row id
    	var id = row.Attribute("id").Value.Trim();
    
    	//get the row elements
    	var d = row.Elements();
       
    	//set the row id first
    	var dataRow = new SoapRow
    	{
    		Id = id
    	};
    
    	// go over each element in the row
    	foreach (var element in d)
    	{
    		// get the row n attribute
    		var n = element.Attribute("n").Value.Trim();
    
    		// get the name of this element by the n attribute from the fields definition.
    		var name = fieldsList.Where(e => e.Aliasnum == n).Select(x => x.Name).First();
    
    		// now just map it using a simple switch statment.
    		switch(name)
    		{
    			case "code":
    				dataRow.Code = element.Value.Trim();
    				break;
    			case "contactinfoid":
    				dataRow.ContactInfoId = element.Value.Trim();
    				break;
    			case "contactnote":
    				dataRow.ContactNote = element.Value.Trim();
    				break;
    			case "contactsource":
    				dataRow.ContactSource = element.Value.Trim();
    				break;
    		}
    
    	}
    
    	// add the row results into the list 
    	rowsList.Add(dataRow);
    
    }
