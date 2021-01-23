    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
        {
            ComboBox cmb = (ComboBox)e.Control;
            cmb.SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);
        }
    }
