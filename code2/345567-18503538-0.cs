	/// <summary>
	/// Makes parsing easier by removing the need to specify namespaces for every element.
	/// </summary>
	private static void RemoveNamespaces(XDocument document)
	{
		var elements = document.Descendants();
		elements.Attributes().Where(a => a.IsNamespaceDeclaration).Remove();
		foreach (var element in elements)
			element.Name = element.Name.LocalName;
	}
