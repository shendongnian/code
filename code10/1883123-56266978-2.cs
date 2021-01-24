    var x = XElement.Parse(xml);
    
    var result = x.Elements("Menu")
        .Select(v =>
        {
            var menuElements = v.DescendantsAndSelf("Menu").ToArray();
    
            var lastEntryElement = menuElements.Last().Element("Entry");
    
            var menuNames = string.Join(" --- ", menuElements.Select(m => m.Attribute("name")?.Value ?? "?"));
    
            return lastEntryElement == null
                ? menuNames
                : $"{menuNames} --- {lastEntryElement.Attribute("name")?.Value ?? "?"}";
        })
        .ToArray();
    /*
    Result of execution:
    
        [0]: "Menu One --- Sub Menu One --- Sub Data One"
        [1]: "Menu Two --- Sub Menu Two --- Sub Sub Menu Two --- Sub Sub Data Two"
        [2]: "Menu Three (no Menu-children) --- Data One"
        [3]: "Menu Four (empty)"
    */
