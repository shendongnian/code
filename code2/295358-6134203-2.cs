      vScrollBar1.Maximum = gridView1.RowCount;
 
        private void vScrollBar1_ValueChanged(object sender, EventArgs e) 
        { 
            gridView1.TopRowIndex = vScrollBar1.Value; 
        } 
        private void gridView1_TopRowChanged(object sender, EventArgs e) 
        { 
           vScrollBar1.Value = gridView1.TopRowIndex;
        } 
        gridView.MouseWheel += new MouseEventHandler(gridView1_TopRowChanged);
