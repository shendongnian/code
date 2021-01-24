    private bool isPicked;
    public bool IsPicked
    {
        get { return isPicked; }
        set { isPicked = value; OnPropertyChanged(); }
    }
