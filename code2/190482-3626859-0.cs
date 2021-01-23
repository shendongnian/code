    private bool _canLike;
    public bool canLike
    {
        get { return this._canLike; }
        set
        {
            if (this._canLike != value)
            {
                this._canLike = value;
                this.OnPropertyChanged("canLike");
            }
        }
