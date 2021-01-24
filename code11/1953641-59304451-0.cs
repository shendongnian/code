    public string TitleMessage
            {
                get
                {
    
                    return TitleMessage;
    
                }
                set
                {
                    if(TitleMessage != value){
                        TitleMessage = value;
                        RaisePropertyChanged("TitleMessage");
                        MyMethod();
                    }
                    
                }
            }
