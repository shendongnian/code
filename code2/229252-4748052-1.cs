    // Linq to XML - Namespaces
    XNamespace ns = "urn:schemas-microsoft-com:office:spreadsheet";
    XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
    XNamespace x = "urn:schemas-microsoft-com:office:excel";
    XNamespace x2 = "http://schemas.microsoft.com/office/excel/2003/xml";
    XNamespace ss = "urn:schemas-microsoft-com:office:spreadsheet";
    XNamespace o = "urn:schemas-microsoft-com:office:office";
    XNamespace html = "http://www.w3.org/TR/REC-html40";
    XNamespace c = "urn:schemas-microsoft-com:office:component:spreadsheet";
    
    // Linq to XML - Document
    XDocument doc = new XDocument(
    	new XDeclaration("1.0", "UTF-8", string.Empty),
    	new XProcessingInstruction("mso-application", "progid=\"Excel.Sheet\""),
    	new XElement(ns + "Workbook",
    		new XAttribute("xmlns", ns.NamespaceName),
    		new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),
    		new XAttribute(XNamespace.Xmlns + "x", x.NamespaceName),
    		new XAttribute(XNamespace.Xmlns + "x2", x2.NamespaceName),
    		new XAttribute(XNamespace.Xmlns + "ss", ss.NamespaceName),
    		new XAttribute(XNamespace.Xmlns + "o", o.NamespaceName),
    		new XAttribute(XNamespace.Xmlns + "html", html.NamespaceName),
    		new XAttribute(XNamespace.Xmlns + "c", c.NamespaceName),
    		new XElement(o + "OfficeDocumentSettings",
    			new XAttribute("xmlns", o.NamespaceName)),
    		new XElement(x + "ExcelWorkbook",
    			new XAttribute("xmlns", x.NamespaceName)),
    		new XElement("Worksheet",
    			new XAttribute(ss + "Name", "Sheet 1"),
    			new XElement("Table", // 1st Table
    				new XElement("Row", // First Row
    					new XElement("Cell", // First Cell on First Row
    						new XElement("Data", new XAttribute(ss + "Type", "String"), "name") // Data in Cell A1
    					),
    					new XElement("Cell",
    						new XElement("Data", new XAttribute(ss + "Type", "String"), "age") // Data in Cell B1
    					)
    				)
    			)
    		)
    	)
    );
    // Loop through a collection. Each iteration is a new row
    foreach (Product product in products)
    {
    	// Linq to XML - Data
    	doc.Descendants("Row").First().AddAfterSelf(
    		new XElement("Row",
    			new XElement("Cell",
    				new XElement("Data", new XAttribute(ss + "Type", "String"), product.Name)), // Data in Cell A2
    			new XElement("Cell",
    				new XElement("Data", new XAttribute(ss + "Type", "String"), product.Age) // Data in Cell B2
    			)
    		)
    	);
    }
    // Namespace fix. Deletes any empty xmlns="" text in every node.
    foreach (XElement e in doc.Root.DescendantsAndSelf())
    { 
    	if (e.Name.Namespace == string.Empty) 
    	{
    		e.Name = ns + e.Name.LocalName;
    	} 
    }
