	//Taken from https://docs.microsoft.com/en-us/dotnet/api/system.xml.schema.extensions.getschemainfo?view=netframework-4.8#System_Xml_Schema_Extensions_GetSchemaInfo_System_Xml_Linq_XElement_
	//with an added null check:
	static void DumpInvalidNodes(XElement el)  
	{  
		if (el.GetSchemaInfo().Validity != XmlSchemaValidity.Valid)  
			Console.WriteLine("Invalid Element {0}",  
				el.AncestorsAndSelf()  
				.InDocumentOrder()  
				.Aggregate("", (s, i) => s + "/" + i.Name.ToString()));  
		foreach (XAttribute att in el.Attributes())  
		{
			var si = att.GetSchemaInfo();
			
			// MUST CHECK FOR NULL HERE
			// Because w3 standard attributes like xmlns:xsi will have null SchemaInfo
			// when not included in the schema, rather than being reported as Invalid.
			if (si != null && si.Validity != XmlSchemaValidity.Valid)  
				Console.WriteLine("Invalid Attribute {0}",  
					att  
					.Parent  
					.AncestorsAndSelf()  
					.InDocumentOrder()  
					.Aggregate("",  
						(s, i) => s + "/" + i.Name.ToString()) + "/@" + att.Name.ToString()  
					);  
		}
		foreach (XElement child in el.Elements())  
			DumpInvalidNodes(child);  
	}
