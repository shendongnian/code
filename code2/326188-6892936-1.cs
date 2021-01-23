    // Load the Push Server Keys
        foreach (string key in jsonObject.keys)
        {
            _psKeys.Add(key);                
        }
        var tabsToRemove = new List<TabPage>();
    // Load the tabKeys with all the keys for the open tabs.
        foreach (TabPage tab in newCallTabControl.TabPages)
        {
            Call call = (Call)tab.Tag;
            if(_psKeys.Contains(call.LogID)
            {               
              _tabKeys.Add(call.LogID); 
            }               
            else
            {
              tabsToRemove.Add(tab)
            }
        }
        tabsToRemove.ForEach(t => newCallTabControl.TabPages.Remove(t));
       
