    protected void protected void gvCommittenti_SelectedIndexChanged(object sender, GridViewSelectEventArgse)
    {
        if (reporter != null)
        {
            //note: I separated this because I'm not testing your string.  You will need
            //      to make sure the string you are sending is correct:
            string eventText = (string)gvCustomers.DataKeys[e.NewSelectedIndex][0];
            
            //this will raise the event to all subscribers:
            reporter(eventText);
        }
    }
