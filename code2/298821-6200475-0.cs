    this.globalEvents.OnSaveButtonClicked += SaveData;
    public void SaveData(object sender, EventArgs e)  
    {  
        globalEvents.RaiseSaveData(EditedGuy);     
        this.globalEvents.OnSaveButtonClicked -= SaveData();
    }
