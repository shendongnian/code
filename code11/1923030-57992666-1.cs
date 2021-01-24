    var key = Registry.CurrentUser.OpenSubKey(reg + SubKeyName);
    if (key != null)
    {
        foreach(string valueName in key.GetValueNames())
        {
            object rawValue = key.GetValue(valueName);
            if (rawValue != null)
            {
                int value = Convert.ToInt32(rawValue);
                //...
            }
        }
    }
