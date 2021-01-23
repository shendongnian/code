    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.Property == MyProperty)
        {
            // do something
        } 
        base.OnPropertyChanged(e);   
    }
