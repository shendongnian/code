    private ModelClass _gettherow;
    public ModelClass GetRowData
    {
        get { return this._gettherow; }
        set
        {
            if (this._gettherow != value)
            {
                this._gettherow = value;
                OnPropertyChanged("GetRowData");
            }
         }
    }
