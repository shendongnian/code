    public static Dictionary<DicKeyCla, DicValCla>
         FindDict(Dictionary<DicKeyCla, Dictionary<DicKeyCla, DicValCla>> index,
                  DicKeyCla needle)
    {
        Dictionary<DicKeyCla, DicValCla> result;
        index.TryGetValue(needle, out result);
        return result;
    }
