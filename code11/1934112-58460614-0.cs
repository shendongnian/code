    void Entry_Completed (object sender, EventArgs e)
    {
        var entryID = ((Entry)sender).Id; //cast sender to access the properties of the Entry
        if (entryID.ToString() == Id1.ToString())
        {
            // Do something...
        }
    }
