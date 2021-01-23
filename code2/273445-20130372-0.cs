    public string[] GetFiles(string path, string pattern)
    {
    	bool lastWildIsHook = false;
    	if(pattern.EndsWith("?"))
    	{
    		pattern = pattern.Substring(0, pattern.Length - 1);
    		lastWildIsHook = true;
    	}
    	var lastWildIndex = Math.Max(pattern.LastIndexOf("*"), pattern.LastIndexOf("?"));
    	var endsWith = pattern.Length > lastWildIndex ? pattern.Substring(lastWildIndex + 1) : pattern;
    	if(!lastWildIsHook)
    		return Directory.GetFiles(path, pattern).Where(p => p.EndsWith(endsWith)).ToArray();
    	else
    		return Directory.GetFiles(path, pattern).Where(p => p.EndsWith(endsWith) || p.Substring(0, p.Length - 1).EndsWith(endsWith)).ToArray();
    }
