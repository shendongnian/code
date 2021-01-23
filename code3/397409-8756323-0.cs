    void GridView1_CellMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
    {
       /* Fake Left Mouse */
        MouseEventArgs fakeLeft = new MouseEventArgs(MouseButtons.Left, e.Clicks, e.X, e.Y, e.Delta);
        this.RaiseMouseEvent(sender, fakeLeft);   
       /* Do normal stuff */
         
    }
