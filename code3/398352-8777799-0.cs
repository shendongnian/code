    public void btnSave_Click(object sender, EventArgs e)
    {
        Button b = sender as Button;
    
        if(b != null)
        {
            if(b.CommandName == "Update")
            {
               // handler the update command
            }
        }
    }
