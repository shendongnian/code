    private DateTime m_createdOn;
    public DateTime CreatedOn
    {
        get { return m_createdOn; }
        set { m_createdOn = value.ToUniversalTime(); }
    }
