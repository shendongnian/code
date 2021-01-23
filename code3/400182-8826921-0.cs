    public string Url
    {
        get { return url.Text; }
        set 
        { 
            if (value != url.Text) 
            { 
                url.Text = value; 
                OnUrlChanged(); // raise event
            }
        }
    }
    public event EventHandler UrlChanged;
    private void OnUrlChanged()
    {
        // raise the UrlChanged event
        if (UrlChanged != null)
            UrlChanged(this, new EventArgs());
    }
