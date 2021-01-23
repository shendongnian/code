    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
        if (dgv.CurrentCell.EditType == typeof(DataGridViewTextBoxEditingControl))
        {
            dgv.BeginEdit(false);            
            ((TextBox)dgv.EditingControl).SelectionStart = 0;
        }
    }
