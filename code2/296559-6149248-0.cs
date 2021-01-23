    private EventHandler foo;
    public event EventHandler Foo 
    {
        add
        {
            if (value != null)
            {
                value(this, EventArgs.Empty);
            }
            foo += value;
        }
        remove
        {
            foo -= value;
        }
    }
