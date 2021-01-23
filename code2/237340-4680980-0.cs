    private int id;
    public int ID
    {
        get { return id; }
        set
        {
            id = value;
            NotifyPropertyChanged("ID");
        }
    }
