    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        var txtBox = e.Control as TextBox;
        if (txtBox != null)
        {
            // Remove an existing event-handler, if present, to avoid 
            // adding multiple handlers when the editing control is reused.
            txtBox.KeyDown -= new KeyEventHandler(underlyingTextBox_KeyDown);
    
            // Add the event handler. 
            txtBox.KeyDown += new KeyEventHandler(underlyingTextBox_KeyDown);
        }
    }
    
    void underlyingTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        // ...
    }
