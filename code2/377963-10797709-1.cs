    void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
    {
        int currentIndex = this.DataGridView1.FirstDisplayedScrollingRowIndex;
        int scrollLines = SystemInformation.MouseWheelScrollLines;
        if (e.Delta > 0) 
        {
            this.DataGridView1.FirstDisplayedScrollingRowIndex 
                = Math.Max(0, currentIndex - scrollLines);
        }
        else if (e.Delta < 0)
        {
            this.DataGridView1.FirstDisplayedScrollingRowIndex 
                = currentIndex + scrollLines;
        }
    }
