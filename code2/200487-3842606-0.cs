    // in form1
    private void Method1()
    {
        using (var form2 = new Form2())
        {
            form2.Show();
            form2.RaiseLoadEvent(EventArgs.Empty);
        }
    }
    // Create this method in form2
    public void RaiseLoadEvent(EventArgs e)
    {
        OnLoad(this, e);
    }
    
    // The OnLoad method already exists in form 2 
    // But it usually looks like this
    protected void OnLoad(EventArgs e)
    {
        var eh = LoadEventHandler;
        if (eh != null) 
        {
           eh(this, e); 
        }
    }
