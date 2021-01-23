    var tabKeysToRemove = _tabKeys.Where(t => !_psKeys.Contains(t));
    foreach (var tabKey in tabKeysToRemove)
    {
        _tabKeys.Remove(tabKey);
        var tabsToRemove = newCallTabControl.TabPages
            .Where(tp => ((Call)tp.Tag).logID == tabKey);
        foreach (var tabPage in tabsToRemove)
        {
            newCallTabControl.TabPages.Remove(tabPage);
        }
    }
