    private static bool MatchesName(XElement el, string name)
    {
        var attr = el.Attribute("Name");
        return attr.Value.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0;
    }
    private bool TermExists(string word)
    {
        return m_xdoc.Descendants("Term").Any(e => MatchesName(e, word));
    }
