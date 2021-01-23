    public static Match MatchOption(string resultadoEjecucionScriptMsBuild, int index, string s)
    {
    	Regex rg = new Regex(s, RegexOptions.Multiline | RegexOptions.IgnoreCase);
    	Match mt = rg.Match(resultadoEjecucionScriptMsBuild, index);
    
    	return !mt.Success ? null : mt;
    }
    
    public static Match MatchOptions(string resultadoEjecucionScriptMsBuild, int index, params string[] strings)
    {
    	foreach (string s in strings)
    	{
    		Match mt = MatchOption(resultadoEjecucionScriptMsBuild, index, s);
    
    		if (mt != null)
    			return mt;
    	}
    
    	return null;
    }
    
    public static bool CheckMsBuildResult(string resultadoEjecucionScriptMsBuild)
    {
    	string s1 = @" ..... ";
    	string s1Mod = @" ..... ";
    	string s11 = @" ..... ";
    
    	// Compilaci�n iniciada a las 28/02/2011 14:56:55.
    	string s12 = @" ..... ";
    
    
    	string s2 = @" ..... ";
    	string s21 = @" ..... ";
    	string s3 = @" ..... ";
    	string s31 = @" ..... ";
    
    	Match mt = MatchOptions(resultadoEjecucionScriptMsBuild, 0, new string[] { s1, s11, s12 });
    	if (mt == null)
    		return false;
    
    	int i = mt.Index + mt.Length;
    
    	mt = MatchOptions(resultadoEjecucionScriptMsBuild, i, new string[] { s2, s21 });
    	if (mt == null)
    		return false;
    
    	i = mt.Index + mt.Length;
    
    	mt = MatchOptions(resultadoEjecucionScriptMsBuild, i, new string[] { s3, s31 });
    
    	return mt != null;
    }
