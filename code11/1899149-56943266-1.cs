    public string ValueFullName
    {
        get { return (string)GetValue(ValueFullNameProperty); }
        set
        {
            SetValue(ValueFullNameProperty, value);
            Notify("ValueFullName"); // This line might never get called
        }
    }
