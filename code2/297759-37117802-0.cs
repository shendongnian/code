    private void AppMainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
       if(e.CloseReason == CloseReason.FormOwnerClosing)
        {
           // do something
        }
        else
        {
           // do nothing
        }
    }
