    void AddSetting(string settingName, string value, ListView table) {
    	ListViewItem setting = new ListViewItem(settingName, value);
    	setting.Name = settingName.ToLower();
    	table.Items.Add(setting);
    }
    string GetSettingValue(string settingName, ListView table) {
    	if (table.Items.ContainsKey(settingName.ToLower())) {
    		return table.Items[settingName.ToLower()].SubItems[1].Text;
    	}
    	return null;
    }
