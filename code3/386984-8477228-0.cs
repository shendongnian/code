    private bool TermExists(string word)
    {
        string upperWord = word.ToUpper();
        return m_xdoc.Descendants("Term")
                     .Any(term => term.Attribute("Name")
                                      .Value.ToUpper()
                                      .Contains(upperWord));
    }
