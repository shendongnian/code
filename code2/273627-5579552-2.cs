    public event EventHandler Click
    {
        add
        {
            ImageButton1.Click += value;
        }
        remove
        {
            ImageButton1.Click -= value;
        }
    }
