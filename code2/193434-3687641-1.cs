    void OnNameChanged()
    {
        if (Name.Length > 50)
        {
            Name = Name.Substring(0, 50);
            LogSomehow("Name truncated");
        }
    }
