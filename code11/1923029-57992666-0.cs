    var key = Registry.CurrentUser.OpenSubKey(reg + SubKeyName);
    if (key != null)
    {
        foreach(string valueName in key.GetValueNames())
        {
            int value = Convert.ToInt32(key.GetValue(valueName));
            //...
        }
    }
