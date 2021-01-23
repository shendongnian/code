    public TMod Modulation
    {
        get { return modulation_; }
        set
        {
            modulation_ = value; 
            NotifyPropertyChanged("Modulation");
            if( modulation == TMod.P25 )
            {
                IFBandwith = TBand.Wide;
            }
        }
     }
