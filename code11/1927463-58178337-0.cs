	XNamespace newNamespace = "http://schemas.something.org/bla/07/WebServices.Stuff";
	
	// Move Addresses elements and children into the new namespace
	foreach (var e in xmlDoc.Descendants().Where(a => a.Name.LocalName == "Addresses").SelectMany(a => a.DescendantsAndSelf()))
	{
		e.Name = newNamespace + e.Name.LocalName;
	}
	
	// Optionally assign the namespace prefix "b" to some container element in scope.
	xmlDoc.Root.SetAttributeValue(XNamespace.Xmlns + "b", newNamespace.NamespaceName);
