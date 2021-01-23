    const string valueNameBlocked = "001f0426";
    const string valueNameSafe = "001f0418";
    
    // Note: I'm using Office 2013 (15.0) and my profile name is "Outlook"
    // You may need to replace the 15.0 or the "Outlook" at the end of your string as needed.
    string keyPath = @"Software\Microsoft\Office\15.0\Outlook\Profiles\Outlook";
    
    string subKey = null;
    var emptyBytes = new byte[] { };
    var semi = new[] { ';' };
    string blocked = null, safe = null;
    
    // I found that my subkey under the profile was not the same on different machines,
    // so I wrote this block to look for it.
    using (var key = Registry.CurrentUser.OpenSubKey(keyPath))
    {
        var match =
            // Get the subkeys and all of their value names
            key.GetSubKeyNames().SelectMany(sk =>
            {
                using (var subkey = key.OpenSubKey(sk))
                    return subkey.GetValueNames().Select(valueName => new { subkey = sk, valueName });
            })
            // But only the one that matches Blocked Senders
            .FirstOrDefault(sk => valueNameBlocked == sk.valueName);
    
        // If we got one, get the data from the values
        if (match != null)
        {
            // Simultaneously setting subKey string for later while opening the registry key
            using (var subkey = key.OpenSubKey(subKey = match.subkey))
            {
                blocked = Encoding.Unicode.GetString((byte[])subkey.GetValue(valueNameBlocked, emptyBytes));
                safe = Encoding.Unicode.GetString((byte[])subkey.GetValue(valueNameSafe, emptyBytes));
            }
        }
    }
    
    // Remove empty items and the null-terminator (sometimes there is one, but not always)
    Func<string, List<string>> cleanList = s => s.Split(semi, StringSplitOptions.RemoveEmptyEntries).Where(e => e != "\0").ToList();
    
    // Convert strings to lists (dictionaries might be preferred)
    var blockedList = cleanList(blocked).Dump("Blocked Senders");
    var safeList = cleanList(safe).Dump("Safe Senders");
    
    byte[] bytes;
    
    // To convert a modified list back to a string for saving:
    blocked = string.Join(";", blockedList) + ";\0";
    bytes = Encoding.Unicode.GetBytes(blocked);
    // Write to the registry
    using (var key = Registry.CurrentUser.OpenSubKey(keyPath + '\\' + subKey, true))
        key.SetValue(valueNameBlocked, bytes, RegistryValueKind.Binary);
    
    // In LINQPad, this is what I used to view my binary data
    string.Join("", bytes.Select(b => b.ToString("x2"))).Dump("Blocked Senders: binary data");
    safe = string.Join(";", safeList) + ";\0"; bytes = Encoding.Unicode.GetBytes(safe);
    string.Join("", bytes.Select(b => b.ToString("x2"))).Dump("Safe Senders: binary data");
