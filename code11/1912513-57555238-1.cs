    private string _testText;
    public string TestText
    {
        get
        {
    
            return _testText;
    
        }
        set
        {
    
            _testText = string.Format("{0:N4}", double.Parse(value, System.Globalization.NumberStyles.Any));
             OnPropertyChanged("TestText");
           
        }
    
    }
