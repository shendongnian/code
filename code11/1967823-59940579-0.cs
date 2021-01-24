    private void DropDown_Click(object sender, EventArgs e) {
      ToolStripItem tsi = sender as ToolStripItem;
      if (tsi != null) {
        MessageBox.Show(tsi.Text);
      }
    }
