     void dataGridView1_EditingControlShowing(object sender,
                DataGridViewEditingControlShowingEventArgs e)
            {
                if (e.Control is ComboBox)
                {
                    ComboBox cmb = e.Control as ComboBox;
    
                    // here you can work on the ComboBox...
                }
            }
