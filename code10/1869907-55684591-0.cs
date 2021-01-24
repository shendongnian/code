    private void dgvTable_EditingControlShowing(object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
        {
            string cn = dgvTable.Columns(dgvTable.CurrentCell.ColumnIndex).Name;
            TextBox tb = (TextBox)e.Control;
    
            tb.KeyPress -= customKeyPress;
            switch (cn)
            {
                case "Column1":
                    {
                        tb.KeyPress += customKeyPress;
                        break;
                    }
    
                default:
                    {
                        break;
                    }
            }
        }
    
        private void customKeyPress(object sender, KeyPressEventArgs e)
        {
            if (Asc(e.KeyChar) == 13)
                e.Handled = true;
        }
