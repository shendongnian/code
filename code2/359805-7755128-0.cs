    private int? _heavyLoadedInt;
    public int HeavyLoading
    {
        get
        {
            if (_heavyLoadedInt == null)
                _heavyLoadedInt = DoHeavyLoading();
            return _heavyLoadedInt.Value;
        }
    }
