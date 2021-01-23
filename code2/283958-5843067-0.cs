    public string GetText(string lang, string fallback)
    {
    	// lang precedes fallback
    	if (lang.CompareTo(fallback) < 1)
    	{
    		return MyDb.Texts.Where(x => x.Language == lang || x.Language == fallback).OrderBy(x => x.Language).FirstOrDefault();
    	}
    	else
    	{
    		return MyDb.Texts.Where(x => x.Language == lang || x.Language == fallback).OrderByDescending(x => x.Language).FirstOrDefault();
    	}
    }
