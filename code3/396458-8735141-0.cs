    private int _tabToSelect = 0;  // Default to first tab.
    public virtual void editClicked(object sender, EventArgs e)
    {
        // Get the data.
        string primaryUser = Request.Form.Get(CompPrimUser.UniqueID);
        string computerName = Request.Form.Get(compCompName.UniqueID);
    
        // Data verification.
        if (computerName == "") {
            // Bad data, reload third tab with user's entered data
            // and inform them they need to fix it.
            _tabToSelect = 2;
            compeditId.Value = POSTED;
            return;
        }
    
        // Display second tab.
        _tabToSelect = 1;
        // Store the data...
    }
