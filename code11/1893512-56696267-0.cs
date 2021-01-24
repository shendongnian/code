    DataGridView.HitTestInfo HT_Info;   // <- Global variable
   
    private void dgv_Test_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        HT_Info = dgv_Test.HitTest(e.X, e.Y);
        dgv_Test.ClearSelection();
        dgv_Test.Rows[HT_Info.RowIndex].Selected = true;
      }
    }
