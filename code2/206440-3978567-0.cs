    public static class WatinExtensions
    {
        public static ElementCollection Children(this Element self)
        {
            return self.DomContainer.Elements.Filter(e => self.Equals(e.Parent));
        }
    }
    
    ElementCollection results = ie.Element(Find.ById("search-results")).Children();
    // and 
    foreach(Element li in results)
    {
        Element info = li.Children().First(e => e.ClassName.Contains("some-info"));
    }
