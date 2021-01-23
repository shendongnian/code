    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    XPathNavigator navigator = doc.CreateNavigator();
    
    string books = GetStringValues("Books: ", navigator, "//Book/Title");
    string authors = GetStringValues("Authors: ", navigator, "//Book/Author");
..
    /// <summary>
    /// Gets the string values.
    /// </summary>
    /// <param name="description">The description.</param>
    /// <param name="navigator">The navigator.</param>
    /// <param name="xpath">The xpath.</param>
    /// <returns></returns>
    private static string GetStringValues(string description, XPathNavigator navigator, string xpath)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(description);
        XPathNodeIterator bookNodesIterator = navigator.Select(xpath);
        while (bookNodesIterator.MoveNext())
           sb.Append(string.Format("{0} ", bookNodesIterator.Current.Value));
        return sb.ToString();
    }
