    private static Lazy<IEnumerable<string>> _searchWordList =
        new Lazy<IEnumerable<string>>(() => DataTools.LoadSearchList());
    public static IEnumerable<string> SearchWordList
    {
        get { return _searchWordList.Value; }
    }
