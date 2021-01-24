    public string md_FilterString
            {
                get { return _FilterString; }
                set
                {
                    if (_FilterString != value)
                    {
                        _FilterString = value;
                        mf_MakeView();
                        OnPropertyChanged("md_FilterString");
                    }
                }
            }
