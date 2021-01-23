    private static void LoadMappingsO()
    {
        var file = new FileInfo("windowsZones.xml");
        if (!file.Exists)
        {
            return;
        }
    
        var map = new Dictionary<string, string>();
        using (var reader = file.OpenText())
        {
            var readerSettings = new XmlReaderSettings { XmlResolver = null, ProhibitDtd = false };
    
            using (var xmlReader = XmlReader.Create(reader, readerSettings))
            {
                var document = new XPathDocument(xmlReader);
                var navigator = document.CreateNavigator();
    
                var nodes = navigator.Select("/supplementalData/windowsZones/mapTimezones/mapZone");
    
                while (nodes.MoveNext())
                {
                    var node = nodes.Current;
                    if (node == null) continue;
    
                    var olsonNames = node.GetAttribute("type", "").Split(' ');
                    var windowsName = node.GetAttribute("other", "");
                    foreach (var olsonName in olsonNames)
                    {
                        if (!map.ContainsKey(olsonName))
                        {
                            map.Add(olsonName, windowsName);
                        }
                    }
                }
            }
        }
    
        using (TextWriter tw = new StreamWriter("dict.txt", false))
        {
            foreach (var key in map.Keys)
            {
                tw.WriteLine(string.Format("{{\"{0}\", \"{1}\"}},", key, map[key]));
            }
        }
    }
