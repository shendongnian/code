     // dummy data
    var transDoc = XDocument.Parse(@"
    <root name='rootAttribute'>
    	<OrderRequest name='one' />
    	<OrderRequest name='two' />
    	<OrderRequest name='three' />
    </root>");
    
    var xmlDoc = XDocument.Parse("<ReplyDocument />");
    
    xmlDoc.Root.Add(
    	transDoc.Root.Elements("OrderRequest").Select(o => 
    		new XElement("ConfirmationElement",
    			new XAttribute("name", (string)o.Attribute("name")),
    			new XElement("ItemDetail"))));
