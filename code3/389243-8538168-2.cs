    private void dtgrd1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        var txtEdit = (TextBox)e.Control;
        txtEdit.KeyPress += EditKeyPress; //where EditKeyPress is your keypress event
    }
    private void EditKeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
                {
                    //Save method for the database
                }
                
    }
