    private string m_Fieldname;
    public string Fieldname
    {
        get { return m_Fieldname; }
        set
        {
            m_Fieldname = value;
            OnPropertyChanged();
        }
    }
    private void OnPropertyChanged([CallerMemberName] string propertyName = "none passed")
    {
        // ... do stuff here ...
    }
