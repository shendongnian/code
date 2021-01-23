    public void LogDisplayedTabs(IEnumerable<Tab> tabs) 
    {
        for(var tab in tabs) 
        {
            if (Sel.IsElementPresent(tab.Identifier))
            {
                Lib.WriteDebugLogs("Test 1: General", "NORMAL", 
                    string.Format("{0} tab present under {1} tab.", tab.Name, tab.ParentName));
            }
        }
    }
