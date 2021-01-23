    public event EventHandler ValueChanged;
    protected virtual void OnValueChanged(object sender, EventArgs e)
    {
        if (ValueChanged != null)
        {
           ValueChanged(sender, e);
        }
    }
    public int Value
    {
        get { return m_value; }
        set { 
            if (m_value == value) return;
            m_value = value;
            OnValueChanged(this, EventArgs.Empty);
        }
    }
