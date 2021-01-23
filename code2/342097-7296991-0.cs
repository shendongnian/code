    private void ChildForm_Leave( object sender, EventArgs e )
    {
        menuItem.Enabled = false;
    }
    private void ChildForm_Enter( object sender, EventArgs e )
    {
        menuItem.Enabled = true;
    }
