    private void gridControl1_ProcessGridKey(object sender, System.Windows.Forms.KeyEventArgs e) {
    if(e.KeyCode == Keys.Enter) {
        (gridControl1.FocusedView as ColumnView).FocusedRowHandle++;
        e.Handled = true;
    }
