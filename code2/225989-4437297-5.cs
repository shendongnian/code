    public static Dictionary<DicKeyCla, DicValCla>
         FindDict(List<Dictionary<DicKeyCla, DicValCla>> haystack,
                  DicKeyCla needle)
    {
        foreach (Dictionary<DicKeyCla, DicValCla> dict in haystack)
            if (dict.ContainsKey(needle))
                return dict;
        return null;
    }
