    public bool IsSelected
    {
        get { return mIsSelected;  }
        set
        {
            mIsSelected = value;
            OnPropertyChanged("IsSelected"); 
            OnPropertyChanged("LabelStatus"); 
        }
    }
    public string LabelStatus 
    { 
        get { return IsSelected? listofitems.Where( ... ).Count() : "-"; } 
    }
