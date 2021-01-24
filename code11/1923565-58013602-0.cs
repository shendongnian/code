csharp
//read setting as comma-separated string from wherever you want to store settings
//e.g. "SSL3, TLS, TLS11, TLS12"
string tlsSetting = GetSetting('tlsSettings')
//by default, support whatever mix of protocols you want..
var tlsProtocols = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
if (!string.IsNullOrEmpty(tlsSetting))
{
    //we have an explicit setting, So initially set no protocols whatsoever.
    SecurityProtocolType selOpts = (SecurityProtocolType)0;
    //separate the comma-separated list of protocols in the setting.
    var settings = tlsSetting.Split(new[] { ',' });
    //iterate over the list, and see if any parse directly into the available
    //SecurityProtocolType enum values.  
    foreach (var s in settings)
    {
        if (Enum.TryParse<SecurityProtocolType>(s.Trim(), true, out var tmpEnum))
        {
            //It seems we want this protocol.  Add it to the flags enum setting
            // (bitwise or)
            selOpts = selOpts | tmpEnum;
        }
    }
                
    //if we've allowed any protocols, override our default set earlier.
    if ((int)selOpts != 0)
    {
        tlsProtocols = selOpts;
    }
}
//now set ServicePointManager directly to use our protocols:
ServicePointManager.SecurityProtocol = tlsProtocols;
This way, you can enable/disable specific protocols, and if any values are added or removed to the enum definition, you won't even need to re-visit the code.
Obviously a comma-separated list of things that map to an enum is a little unfriendly as a setting, but you could set up some sort of mapping or whatever if you like of course... it suited our needs fine.
