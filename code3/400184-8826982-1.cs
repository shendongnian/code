    public event EventHandler UrlChanged;
    protected virtual void OnUrlChanged()
    {
        var handler = UrlChanged;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
    [Bindable(true)]
    [Browsable(true)]
    public string Url
    {
        get
        {
            return url.Text;
        }
        set
        {
            if (value != url.Text)
            {
                url.Text = value;
                OnPropertyChanged("Url");
                OnUrlChanged();
            }
        }
    }
