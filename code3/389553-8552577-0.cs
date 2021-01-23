    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is DataGridViewComboBoxEditingControl)
        {
            DataGridViewComboBoxEditingControl cb =  
                e.Control as DataGridViewComboBoxEditingControl; 
            cb.DropDownStyle = ComboBoxStyle.Simple;
            cb.KeyUp += new KeyEventHandler(cb_KeyUp);
        }
    }
