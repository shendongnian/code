    public Threshold : INotifyProperyChanged
    {
    ...
        public Threshold()
        {
            ...
            this.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e) { if (e.PropertyName != nameof(WorkAround)) { NotifyPropertyChanged(nameof(WorkAround)); } };
        }
    ...
    public bool WorkAround { set; get; }
    }
