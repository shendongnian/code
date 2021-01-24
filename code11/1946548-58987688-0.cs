    public static warMod Gen(List<AtMap> atMaps)
    {
        List<AtMap> atMapList = new List<AtMap>();
        foreach (var a in atMaps)
            atMapList.Add(new AtMap(a));
    
        return new warMod { AtMapArr = atMapList };
    }
    
    public class AtMap
    {
    	public AtMap(AtMap a)
    	{
            if (!string.IsNullOrEmpty(a.srSys))
                srSys = a.srSys;
            if (!string.IsNullOrEmpty(a.desSys))
                desSys = a.desSys;
            if (a.srFl != null)
                srFl = a.srFl;
            if (a.desFl != null)
                desFl = a.desFl;
        }
    }
