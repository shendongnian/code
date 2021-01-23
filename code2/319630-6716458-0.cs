    private int m_dependOne;
    public int DependOne
    {
        get { return m_dependOne; }
        set
        {
            m_dependOne = value;
            OnPropertyChanged("DependOne");
            OnPropertyChanged("Count");
        }
    }
    private int m_dependTwo;
    public int DependTwo
    {
        get { return m_dependTwo; }
        set
        {
            m_dependTwo = value;
            OnPropertyChanged("DependTwo");
            OnPropertyChanged("Count");
        }
    }
    public int Count
    {
        get
        {
            return m_dependOne + m_dependTwo;
        }
    }
