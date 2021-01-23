    private XElement? GetTerm(string word)
    {
          var query = from term in m_xdoc.Descendants("Term")
                      where term.Attribute("Name").Value.ToUpper().Contains(word.ToUpper())
                      select term;
    
          return query.FirstOrDefault();
    }
