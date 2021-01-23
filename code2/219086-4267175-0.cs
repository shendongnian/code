    private int age;
    public int Age
    {
        get { return age; }
        set
        {
            if (age != value)
            {
                age = value;
                OnAgeChanged(EventArgs.Empty);
            }
        }
    }
    public event EventHandler AgeChanged;
    protected virtual void OnAgeChanged(EventArgs e)
    {
        var handler = AgeChanged;
        if (handler != null)
            handler(this, e);
    }
