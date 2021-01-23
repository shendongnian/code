    private string _textBoxContent;
    public string TextBoxContent
    {
        get { return _textBoxContent; }
        set
        {
            _textBoxContent = value;
            OnPropertyChanged("TextBoxContent");
        }
    }
