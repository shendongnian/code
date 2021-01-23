    private static string AtomNamespace = "http://www.w3.org/2005/Atom";
    
    public static XName Entry = XName.Get("entry", AtomNamespace);
    
    public static XName Published = XName.Get("published", AtomNamespace);
    
    public static XName Title = XName.Get("title", AtomNamespace);
    
    var items = doc.Descendants(AtomConst.Entry)
                    .Select(entryElement => new FeedItemViewModel()
                    new {
                      Title = entryElement.Descendants(AtomConst.Title).Single().Value,
                      ...
                    });
