    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        // Get the index of the item the mouse is below.
        rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;
    
        // Here we also check that the HitTest happened on a RowHeader
        if (rowIndexFromMouseDown != -1 && (dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.RowHeader))
        {
            // Remember the point where the mouse down occurred. 
    	 // The DragSize indicates the size that the mouse can move 
    	 // before a drag event should be started.                
            Size dragSize = SystemInformation.DragSize;
    
            // Create a rectangle using the DragSize, with the mouse position being
            // at the center of the rectangle.
            dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                           e.Y - (dragSize.Height / 2)),
    							dragSize);
        }
        else
            // Reset the rectangle if the mouse is not over an item in the ListBox.
            dragBoxFromMouseDown = Rectangle.Empty;
    }
