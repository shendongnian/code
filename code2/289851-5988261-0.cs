    Public Visibility Line1
    {
        get
        {
            return m_Line1Visibility;
        }
        set
        {
        if(value != m_Line1Visibility)
            {
            m_Line1Visibility = value
            OnPropertyChanged("Line1");
            }
        }
    }
