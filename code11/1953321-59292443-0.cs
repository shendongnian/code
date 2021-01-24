    // Actual data source
    Dictionary<string, string> inpLangList = new Dictionary<string, string>();
    // A presentation of your data that you can group, sort, filter, etc
    public ICollectionView InpLangList { get; set; }
    private bool _isShowEmptyFields;
    public bool IsShowEmptyFields 
    {
        get { return _isShowEmptyFields; }
        set 
        {
            _isShowEmptyFields = value;
            // if the presentation of your data is assigned - filter it
            InpLangList?.Refresh();
        }
    }
    
    // ViewModel constructor
    public VM()
    {
        inpLangList.Add("id1", "One");
        inpLangList.Add("id2", "");
        inpLangList.Add("id3", "");
        inpLangList.Add("id4", "Four");
        inpLangList.Add("id5", "Five");
        // note what's going next:
        // assigning the data source to it's presentation (view)
        InpLangList = CollectionViewSource.GetDefaultView(inpLangList);
        // assigning filter that will be applied to your data source
        // before the showing it within the UI
        InpLangList.Filter = (obj) => 
        {
            if (!(obj is KeyValuePair<string, string> pair))
                return false;
             return !IsShowEmptyFields || string.IsNullOrEmpty(pair.Value);
        };
    }
