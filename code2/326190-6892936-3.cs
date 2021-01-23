        var jsonResult = _pushServer.GetWebRequest(_pushServer.GetNewCallUrl(_locationID, _clientID));
        var jsonObject = _pushServer.GetJsonObject(jsonResult);
        _tabKeys.Clear();
        _psKeys.Clear();
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
