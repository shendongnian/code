    private void Form_OnLoad(object sender, EventArgs e){
        dgvArmazem.CellEnter += new DataGridViewCellEventHandler(dgvArmazem_CellEnter);
    }
    
    void dgvArmazem_CellEnter(object sender, DataGridViewCellEventArgs e)
            {
                DataGridView dg = (DataGridView)sender;
    
                if (dg.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
                {
                    SendKeys.Send("{F4}");
                }
            }
