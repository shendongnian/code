    private ViewModelBase currentViewModel;
    public ViewModelBase CurrentViewModel
    {
        get { return currentViewModel; }
        set { currentViewModel = value; NotifyPropertyChanged(); }
    }
