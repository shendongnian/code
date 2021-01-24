    public static void IsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (OnSelected != null) 
        {
            OnSelected(this, new EventArgs(/* Whatever you want to publish here*/));
        }
    }
