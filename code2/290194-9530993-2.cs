    private static void LoadMappings()
    {
        var map = new Dictionary<string, string>();
        var xdoc = XDocument.Load("windowsZones.xml");
    
        var zones = xdoc.XPathSelectElements("/supplementalData/windowsZones/mapTimezones/mapZone");
        foreach (var zone in zones)
        {
            var olsonNames = zone.Attribute("type")?.Value.Split(' ');
            if (olsonNames == null)
                continue;
    
            var windowsName = zone.Attribute("other")?.Value;
            if (string.IsNullOrWhiteSpace(windowsName))
                continue;
    
            foreach (var olsonName in olsonNames)
            {
                map[olsonName] = windowsName;
            }
        }
    
        using (TextWriter tw = new StreamWriter("dict.txt", false))
        {
            foreach (var key in map.Keys)
            {
                tw.WriteLine($"{{\"{key}\", \"{map[key]}\"}},");
            }
        }
    }
