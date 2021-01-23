	/// <summary>
	/// Makes parsing easier by removing the need to specify namespaces for every element.
	/// </summary>
	private static void RemoveNamespaces(XDocument document)
	{
        var elements = document.Descendants();
        elements.Attributes().Where(a => a.IsNamespaceDeclaration).Remove();
        foreach (var element in elements)
        {
            element.Name = element.Name.LocalName;
            var strippedAttributes =
                from originalAttribute in element.Attributes().ToArray()
                select (object)new XAttribute(originalAttribute.Name.LocalName, originalAttribute.Value);
            //Note that this also strips the attributes' line number information
            element.ReplaceAttributes(strippedAttributes.ToArray());
        }
	}
