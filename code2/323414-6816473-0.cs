    public void UpdateSystemMode()
    {
        if (this.InvokeRequired)
             this.BeginInvoke((Action)UpdateSystemMode);
        else
            systemMode.UpdateSystemMode(); 
    }
