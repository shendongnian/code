    private int _number = 0;
    public int Number
    {
        get { return _number; }
        set
        {
            if (_number != value)
            {
                _number = value;
                //After the setter updates the backing variable, this Updates the UI.
                NotifyPropertyChanged("Number");
            }
        }
    }
    public void increase(object sender, RoutedEventArgs e)
    {
        Number += 1;
    }
    public void decrease(object sender, RoutedEventArgs e)
    {
        Number -= 1;
    }
