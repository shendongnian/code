    private bool _oCommonMuteA;
    public bool oCommonMuteA
    {
        get { return _oCommonMuteA; }
        set 
        { 
            SetField(ref _oCommonMuteA, value); 
            OnPropertyChanged(nameof(oCommonMuteA));
        }
     }
