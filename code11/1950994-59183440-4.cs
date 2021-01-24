    private SomeType someProperty = null;
    [DefaultValue(null)]
    public SomeType SomeProperty 
    {
        get { return someProperty; }
        set
        {
            if (value == null)
                MessageBox.Show("Why null????");
            else
                someProperty = value;
        }
    }
