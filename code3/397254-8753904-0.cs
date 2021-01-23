    private string _CommandText;
    public string CommandText
    {
        get
        {
            return this._CommandText;
        }
        set
        {
            if(!(value == this._CommandText))
            {
                this._CommandText = value;
                if (this._CommandText.Contains("\r\n"))
                {
                    ParseCommand(this._CommandText)
                    this._CommandText = null;
                }
                base.OnPropertyChanged("CommandText");
            }
        }
    }
 
