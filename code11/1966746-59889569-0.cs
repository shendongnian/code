    public bool IsEnabledCombo { get { return clickStatus 
                                           && OtherStatus 
                                           && !string.IsNullOrEmpty( UserText); }
    public bool ClickStatus { get { return _clickStatus; } 
                             set { _clickStatus = value; 
                                   NotifyPropertyChanged("ClickStatus");
                                   NotifyPropertyChanged("IsEnabledCombo");
                                 }}
     public bool OtherStatus { get { return _otherStatus; } 
                             set { _clickStatus = value; 
                                   NotifyPropertyChanged("OtherStatus");
                                   NotifyPropertyChanged("IsEnabledCombo");
                                 }}   
      public string UserText { ... 
                              set { _userText = value;                            
                                   NotifyPropertyChanged("UserText");
                                   NotifyPropertyChanged("IsEnabledCombo");
