    private static void LoadMappings()
        {
            var file = new FileInfo("windowsZones.xml");
            if (!file.Exists)
            {
                return;
            }
            Dictionary<string, string> map = new Dictionary<string, string>();
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
                        XPathNavigator node = nodes.Current;
                        if (node == null) continue;
                        string[] olsonNames = node.GetAttribute("type", "").Split(' ');
                        string windowsName = node.GetAttribute("other", "");
                        foreach (string olsonName in olsonNames)
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
                foreach (string key in map.Keys)
                {
                    tw.WriteLine(string.Format("{{\"{0}\", \"{1}\"}},", key, map[key]));
                }
            }
        }
    }
