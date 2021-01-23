	public static Element FindElementContaining(IElementsContainer ie, string text)
	{
		Element matchingElement = null;
		foreach (Element element in ie.Elements)
		{
			if (element.Text == null) continue;
			if (!element.Text.ToLower().Contains(text.ToLower())) continue;
			// If the element found has more inner html than the one we've already matched, it can't be the immediate parent!
			if (matchingElement != null && element.InnerHtml.Length > matchingElement.InnerHtml.Length) continue;
			matchingElement = element;
		}
		return matchingElement;
	}
