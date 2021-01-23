        string str = string.Empty;
        int i = 0;
        private void dg_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            str = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
        }
        void dg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.TextChanged += new EventHandler(tb_TextChanged);
        }
        void tb_TextChanged(object sender, EventArgs e)
        {
            if (i == 0)
            {
                i++;
                DataGridViewTextBoxEditingControl dgv = (DataGridViewTextBoxEditingControl)sender;
                string curVal = dgv.Text;
                dgv.Text = str + curVal;
                dgv.SelectionStart = dgv.Text.Length;
            }
            dg.EditingControlShowing -= new DataGridViewEditingControlShowingEventHandler(dg_EditingControlShowing);
            dg.CellEnter -= new DataGridViewCellEventHandler(dg_CellEnter);
        }
        private void dg_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            i = 0;
        }
