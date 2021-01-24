    private SomeType someProperty = null;
    public SomeType SomeProperty 
    {
        get { return someProperty; }
        set
        {
            if (value == null && !DesignMode)
                MessageBox.Show("Why null????");
            else
                someProperty = value;
        }
    }
