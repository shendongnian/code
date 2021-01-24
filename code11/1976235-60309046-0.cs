    string xml = 
    @"<incident>
        <id>1234</id>
        <number>5678</number>
        <name>This is a name</name>
        <state>Awaiting Input</state>
        <priority>Medium</priority>
        <category>
            <id>99999</id>
            <name>Applications</name>
            <default_tags>applications</default_tags>
            <parent_id nil=""true"" />
            <default_assignee_id nil=""true"" />
        </category>
    </incident>";
    List<String> innerTextNode = new List<string>();
    XmlDocument XmlDoc= new XmlDocument();
    XmlDoc.LoadXml(xml);
    XmlElement root = XmlDoc.DocumentElement;
    XmlNodeList nodes = root.ChildNodes;
    XmlNodeList childs;
    
	foreach (XmlNode anode in nodes)
	{
        // The next is for any NODE that will have childnodes
        // bool havechilds = anode.ChildNodes.OfType<XmlNode>().Any(x => x.NodeType != XmlNodeType.Text)
        if (!anode.LocalName.Equals("category", StringComparison.CurrentCulture))
        {
            // The node is only text, no has childnodes
            // So capturing InnerText
            innerTextNode.Add(anode.InnerText);
        }
        else
        {
            childs = nodo.ChildNodes;
            foreach (XmlNode childone in childs)
			{
			    // So capturing InnerText
                innerTextNode.Add(childone.InnerText);
			}
        }
    }
