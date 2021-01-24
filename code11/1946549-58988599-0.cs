    public static warMod Gen(List<AtMap> atMaps)
    {
        var atMapList = new List<AtMap>();
    
        foreach (var a in atMaps)
        {
            var atMap = new AtMap
            {
                srSys = a.srSys,
                desSys = a.desSys,
                srFl = a.srFl ?? default(int),
                desFl = a.desFl ?? default(int)
            };
    
            atMapList.Add(atMap);
        }
        return new warMod { AtMapArr = atMapList };
    }
