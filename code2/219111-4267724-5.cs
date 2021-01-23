	var a = new MyObject();
	var t = a.GetType().GetProperty("City");
	string xmlMemberName = "M:" + a.FullName + t.Name;
	var xmlDoc = new XmlDocument();
	xmlDoc.Load("you_xml_comments_file.xml");
	var membersNode = xmlDoc.DocumentElement["members"];
	string summary = "";
	if(membersNode != null)
	{
		foreach(XmlNode memberNode in membersNode.ChildNodes)
		{
			if(memberNode.Attributes["name"].Value == xmlMemberName)
			{
				summary = memberNode["summary"].InnerText;
				break;
			}
		}
	}
	Console.WriteLine(summary);
