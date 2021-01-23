    // using page resources
    public Style ABC
    {
        get { return (Style) this.Resources["_myStyle"]; }
    }
    // using application resources
    public Style ABC
    {
        get { return (Style) App.Current.Resources["_myStyle"]; }
    }
