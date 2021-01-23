    /// <summary>
    /// Gets the list of tabs to show.
    /// </summary>
    /// <param name="dictionary"></param>
    /// <returns></returns>
    public static IList<TabItemDisplay> TabListGet(this ViewDataDictionary dictionary)
    {
    	IList<TabItemDisplay> result;
    	if (dictionary.ContainsKey("TabList"))
    		result = dictionary["TabList"] as IList<TabItemDisplay>;
    	else
    		result = null;
    	return result;
    }
    
    /// <summary>
    /// Sets the list of tabs to show.
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="tabList"></param>
    /// <returns></returns>
    public static IList<TabItemDisplay> TabListSet(this ViewDataDictionary dictionary, IList<TabItemDisplay> tabList)
    {
    	dictionary["TabList"] = tabList;
    	return tabList;
    }
