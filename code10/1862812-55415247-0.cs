    internal bool ShowCheckBox
    {
        get
        {
            return cb.Visible;
        }
        set
        {
            if (cb.Visible != value)
            {
                cb.Visible = value;
                OnShowCheckBoxChanged();
            }
        }
    }
