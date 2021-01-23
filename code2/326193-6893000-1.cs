    var tabKeysToRemove = _tabKeys.Where(t => !_psKeys.Contains(t)).ToList();
    foreach (var tabKey in tabKeysToRemove)
    {
        _tabKeys.Remove(tabKey);
        var tabsToRemove = newCallTabControl.TabPages
            .Where(tp => ((Call)tp.Tag).logID == tabKey).ToList();
        tabsToRemove.forEach(t => newCallTabControl.TabPages.Remove(t));
    }
