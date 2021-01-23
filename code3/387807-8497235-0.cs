    var doc = XDocument.Parse(xml);
    doc
    .Root                         //Elements under the root element.
    .Elements("item")             //Select the elements called "item".
    .Select(                      //Projecting each item element to something new.
    	item =>                   //Selecting each element in the item.
    		item                  //And creating a new dictionary using the element name
    		.Elements()           // as the key and element value as the value. 
    		.ToDictionary(xe => xe.Name.LocalName, xe => xe.Value))
    .ToList();
