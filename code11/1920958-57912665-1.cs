    private ObservableCollection<string> myButtons;
    public ObservableCollection<string> MyButtons
    {
        get { return myButtons; }
        set
        {
            if (myButtons == null)
            {
                myButtons = value;
                OnPropertyChanged("MyButtons");
            }
        }
    }
    private void PopulateButtons()
    {
        List<string> buttonsToAdd = new List<string>();
        foreach (var item in Options)
        {
            buttonsToAdd.Add(item + "1");
        }
        MyButtons = new ObservableCollection<string>(buttonsToAdd);
    }
