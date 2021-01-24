    public void IsAllEntriesFilled()
    {
        if (!string.IsNullOrEmpty(Entry1Text) && !string.IsNullOrEmpty(Entry2Text) && !string.IsNullOrEmpty(Entry3Text))
        {
            IsButtonEnabled = true;
        }
        else
        {
            IsButtonEnabled = false;
        }
    }
