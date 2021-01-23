    private void form_KeyDown(object sender, 
        System.Windows.Forms.KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Alt && /*menu is not displayed*/) 
        {
            // display menu
        } 
    }
    private void form_KeyUp(object sender,
        System.Windows.Forms.MouseEventArgs e)
    {
        if (/*check if mouse is NOT over menu using e.X and e.Y*/)
        {
            // hide menu
        }
    }
