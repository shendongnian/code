    private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
       if (e.Button == System.Windows.Forms.MouseButtons.Right)
       {
          contextMenuStrip1.Show(dataGridView1, x,y);
       }
    }
