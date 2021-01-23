    protected virtual void OnNameChanged()
    {
        EventHandler nameChanged = NameChanged; // always a good idea to store in a local variable
        if (nameChanged != null)
        {
            nameChanged(this, new EventArgs());
        }
    }
