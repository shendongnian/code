    private static IEnumerable<string> _searchWordList;
    public static IEnumerable<string> SearchWordList
    {
        get 
        { 
            return _searchWordList ?? 
                ( _searchWordList = DataTools.LoadSearchList()); 
        }
    }
