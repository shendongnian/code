    public MyClass()
    {
        a.PropertyChanged += new PropertyChangedEventHandler(UpdateC);
        b.PropertyChanged += new PropertyChangedEventHandler(UpdateC);
    }
    void UpdateC(object sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged("C");
    }
