    void tvMouseUp(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
        {
            // Select the clicked node
            tv.SelectedNode = tv.GetNodeAt(e.X, e.Y);
    
            if(tv.SelectedNode != null)
            {
                myContextMenuStrip.Show(tv, e.Location)
            }
        }
    }
