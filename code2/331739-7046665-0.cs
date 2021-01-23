    // initialize in your constructor
    public PeriodsCollection AvailablePeriods { get; private set; }
    public int SamplingFrequencyIndex
    {
        get { return samplingFrequencyIndex; }
        set
        {
            samplingFrequencyIndex = value;
            RaisePropertyChanged("SamplingFrequencyIndex");
            var view = CollectionViewSource.GetDefaultView(AvailablePeriods) as ListCollectionView;
            view.Filter = o => ((SamplingPeriod)o).GroupIndex >= value;
        }
    }
