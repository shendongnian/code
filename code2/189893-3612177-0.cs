    public event EventHandler SaveButtonClick
    {
        add { btnSave.Click += value; }
        remove { btnSave.Click -= value; }
    }
