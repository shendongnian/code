    //Assumes your mode enum is defined and named WindowModes
    private WindowModes m_CurrentMode;
    public WindowModes
    {
        get { return m_CurrentMode; }
        set
        {
             m_CurrentMode = value;
             if (PropertyChanged != null)
                 PropertyChanged(this, new PropertyChangedEventArgs("CanConfigure"));
        }
    }
    public bool CanConfigure
    {
        return(WindowMode == WindowModes.Online)
    }
