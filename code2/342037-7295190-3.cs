    private string localTexT
    public string TexT
    {
        get { return localTexT; }
        set
        {
            localTexT = value;
            NotifyPropertyChanged("TexT");
        }
    }
