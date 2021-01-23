    Complete Answer
    You need to set Focus Datagridview
    private void DataGridView1_MouseEnter(object sender, EventArgs e)
            {
                DataGridView1.Focus();
            }
    
    then Add Mouse wheel event in Load function 
    DataGridView1.MouseWheel += new MouseEventHandler(DataGridView1_MouseWheel);
    
    Finally Create Mouse wheel function
    
    void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
    {
        int currentIndex = this.DataGridView1.FirstDisplayedScrollingRowIndex;
        int scrollLines = SystemInformation.MouseWheelScrollLines;
    
        if (e.Delta > 0) 
        {
            this.DataGridView1.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
        }
        else if (e.Delta < 0)
        {
            if (this.DataGridView1.Rows.Count > (currentIndex + scrollLines))
                this.DataGridView1.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
        }
    }
    
    It works fine for me.
