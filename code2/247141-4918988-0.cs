    // supporting methods to build parts of the string
    static string ElementNotInList<T>(string element, params T[] list)
    {
        return String.Join(" and ", list.Select(x => String.Concat(element, "!=", x)));
    }
    static string ElementInList<T>(string element, params T[] list)
    {
        return String.Join(" or ", list.Select(x => String.Concat(element, "=", x)));
    }
    var excludeSubmenus = new[] { 2905, 323 };
    var xpath = String.Join("|",
        String.Format("//Menu[{0}]/Item[ItemLevel={1} and ItemType!='Javascript']",
            ElementNotInList("MenuId", excludeSubmenus), iLevel),
        String.Format("//Menu[{0}]/Item[ItemLevel={1} and ItemType='content']",
            ElementInList("MenuId", excludeSubmenus), iLevel)
    );
    var nextLevelNodeList = currentNode.SelectNodes(xpath);
