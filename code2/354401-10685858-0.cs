    DataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler (DataGridView1_EditingControlShowing);
    private void dbg_EditingControlShowing (object sender, DataGridViewEditingControlShowingEventArgs e) {
            TextBox txb = e.Control as TextBox;
            txb.PreviewKeyDown += (S, E) => {
                if (E.KeyCode == Keys.Enter) {
                    DataGridView1.CurrentCell = dbg.CurrentRow.Cells["Column_name"];
                    //Or any code you ...
                }
            };
    }
