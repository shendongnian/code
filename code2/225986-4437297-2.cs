    public static Dictionary<DicKeyCla, DicValCla>
         FindDict(List<Dictionary<DicKeyCla, DicValCla>> haystack,
                  DicKeyCla needle)
    {
        return haystack.Where(dict => dict.ContainsKey(needle)).FirstOrDefault();
    }
