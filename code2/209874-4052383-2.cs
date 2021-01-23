    private object dataSource;
    public object DataSource {
        get {
            if (value != dataSource) {
                dataSource = value;
                RaisePropertyChanged("DataSource");
            }
        }
    }
