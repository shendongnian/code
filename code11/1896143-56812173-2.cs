    private double tabControlWidth = 0;
    public double TabControlWidth
    {
        get { return tabControlWidth; }
        set
        {
            if (this.tabControlWidth != value)
            {
                tabControlWidth = value;
                this.NotifyPropertyChanged("TabControlWidth");
            }
        }
    }
    private double tabControlHeight = 0;
    public double TabControlHeight
    {
        get { return tabControlHeight; }
        set
        {
            if (this.tabControlHeight != value)
            {
                tabControlHeight = value;
                this.NotifyPropertyChanged("TabControlHeight");
            }
        }
    }
