    // old version
    public TValue this[TKey key]
    {
        get { return (TValue)_keyedEntryCollection[key].Value; }
        set { DoSetEntry(key, value);}
    }
    // new version
    public TValue this[TKey key]
    {
        get { return (TValue)_keyedEntryCollection[key].Value; }
        set
        {
            DoSetEntry(key, value);
            OnPropertyChanged(Binding.IndexerName);
        }
    }
