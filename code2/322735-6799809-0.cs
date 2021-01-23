    XNamespace atom = "http://www.w3.org/2005/Atom";
    var list = from y in xelement.Descendants(atom+"entry")
                   select new Update()
                   {
                       Title = y.Element(atom+"title").Value,
                       Pubdate = y.Element(atom+"published").Value,
                       Descr = y.Element(atom+"content").Value,
                       Link = y.Element(atom+"link").Attribute("href").Value
                   };
