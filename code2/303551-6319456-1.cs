    private string testString;
    public string TestString
    {
        get { return testString; }
        set {
            if (testString != value) {
                testString = value;
                RaisePropertyChanged("TestString");
            }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
