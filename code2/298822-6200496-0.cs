    public void SaveButtonClicked(object sender, EventArgs e)
    {
        SaveData();
    }
    this.globalEvents.OnSaveButtonClicked += SaveButtonClicked;
    
    this.globalEvents.OnSaveButtonClicked -= SaveButtonClicked;
