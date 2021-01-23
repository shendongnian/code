    private bool ShowUID { get; set; }
    private int? ShouldThisBeWrittenOut(int UserID)
    {
    	if (ShowUID) {
    		ShowUID = false;
    		return UserID;
    	} else {
    		return null;
    	}
    }
    private void SetShowIDToTrue()
    {
    	ShowUID = true;
    }
