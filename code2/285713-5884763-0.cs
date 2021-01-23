     private void dataGridView_MouseUp(object sender, MouseEventArgs e)
    {
       DataGridView.HitTestInfo hitTestInfo;
      if (e.Button == MouseButtons.Right)
      {
          hitTestInfo = dataGridView.HitTest(e.X, e.Y);
        // If column is first column
        if (hitTestInfo.Type == DataGridViewHitTestType.Cell && hitTestInfo.ColumnIndex == 0)
            contextMenuForColumn1.Show(dataGridView, new Point(e.X, e.Y));
        // If column is second column
        if (hitTestInfo.Type == DataGridViewHitTestType.Cell && hitTestInfo.ColumnIndex == 1)
            contextMenuForColumn2.Show(dataGridView, new Point(e.X, e.Y));
    }
    } 
