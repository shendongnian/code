    private void _dgwMain_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
             DataGridView.HitTestInfo info = _dgwMain.HitTest(e.X, e.Y);
             //now you can use info.RowIndex and info.CellIndex (not sure for porporty          
             //name) to generate menu you want
        }
    }
