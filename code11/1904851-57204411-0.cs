C#
string xml = "<plist>"
		+ "<properties name=\"prop\">"
		+ "<property><type>0</type><dataType>0</dataType><key>key</key><value>Properties.Name</value><readOnly>0</readOnly></property>"
		+ "<property><type>0</type><dataType>0</dataType><key>value</key><value>Image1</value><readOnly>0</readOnly></property>"
		+ "</properties>"
		+ "<properties name=\"prop\">"
		+ "<property><type>0</type><dataType>0</dataType><key>key</key><value>Properties.Name</value><readOnly>0</readOnly></property>"
		+ "<property><type>0</type><dataType>0</dataType><key>value</key><value>Text1</value><readOnly>0</readOnly></property>"
		+ "</properties>"
		+ "</plist>";
	XmlDocument doc = new XmlDocument();
	doc.LoadXml(xml);
	XmlNodeList values = doc.GetElementsByTagName("value");
	string result = "Properties.Name";
	for (int i = 0; i < values.Count; i++)
		if (values[i].InnerText == result)
		{
			Console.Write(values[i + 1].InnerText + ", ");
			i++;
		}
	Console.WriteLine("\n\n another way:");
	
	var lst = values.Cast<XmlNode>().ToList();
	
	lst.ForEach(f => {
		if(f.InnerText==result)
		Console.WriteLine(lst[lst.IndexOf(f)+1].InnerText + ", ");
	});
