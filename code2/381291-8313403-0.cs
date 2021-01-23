    private MenuItem _oldMenuItem;
    
    void ColorSelect(object sender, EventArgs e)
        {
            if(_oldMenuItem != null) _oldMenuItem.Text = someText;
            _oldMenuItem = sender as MenuItem;
    
            lblSelectedColor.Text = ((MenuItem) sender).Text;
        }
