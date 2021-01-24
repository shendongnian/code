    Entry myEntry = new Entry()
    {
        Id = Guid.NewGuid()
    };
    ...
    void Entry_Completed (object sender, EventArgs e)
    {
        var entryID = ((Entry)sender).Id; //cast sender to access the properties of the Entry
        if (entryID.ToString() == myEntry.Id.ToString())
        {
            // Do something...
        }
    }
