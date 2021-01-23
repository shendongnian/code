    public void ClosingEvent (...)
    {
        if(this.ToValidate)
        {
            this.Validate();
            // Or e.Cancel; I don't know exactly know what you want to prevent...
        }
    }
    
    public void ButtonClick(...)
    {
       this.ToValidate = false;
       this.Close();
    }
