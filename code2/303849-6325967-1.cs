    private double m_distanceBox;
    public double DistanceBox
    {
        get { return m_distanceBox; }
        set
        {
            if (m_distanceBox != value)
            {
                m_distanceBox = value;
                NotifyPropertyChanged("DistanceBox");
                NotifyPropertyChanged("WidthBased");
            }
        }
    }
