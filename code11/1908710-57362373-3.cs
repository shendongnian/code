    // Start the topIndexes array with all invalid indexes
    var topIndexes = new[] {-1, -1, -1};
    for (var settingIndex = 0; settingIndex < Settings.Length; settingIndex++)
    {
        var setting = Settings[settingIndex];
        var topIndexLessThanSetting = -1;
        // Find the smallest topIndex setting that's less than this setting
        for (int topIndex = 0; topIndex < topIndexes.Length; topIndex++)
        {
            if (topIndexes[topIndex] == -1)
            {
                topIndexLessThanSetting = topIndex;
                break;
            }
            if (setting <= Settings[topIndexes[topIndex]]) continue;
            if (topIndexLessThanSetting == -1 ||
                Settings[topIndexes[topIndex]] < Settings[topIndexes[topIndexLessThanSetting]])
            {
                topIndexLessThanSetting = topIndex;
            }
        }
        topIndexes[topIndexLessThanSetting] = settingIndex;
    }
    // topIndexes = { 1, 2, 8 }
