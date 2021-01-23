    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
     {
        if (e.Control is DataGridViewTextBoxEditingControl tb)
                {
                    tb.KeyDown -= dataGridView1_KeyDown;
                    tb.KeyDown += dataGridView1_KeyDown;
                }
     }
    
    //then in your keydown event handler, execute your code
    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
     {
        if (e.KeyData == (Keys.Alt | Keys.S))
        {
             //save data
        }
     }
