    foreach (XmlNode node in relatoriosStaticos.DocumentElement.ChildNodes)
    {
    	if (node.Attributes["Titulo"].InnerText == string.Empty)
    	{
    		continue;
    	}
    	else
    	{
    		relatorios.Add(node.Attributes["Titulo"].InnerText,
    			string.Concat(node.Attributes["Url"].InnerText, id));
    	}
    }
