    private void tsmi_ViewMenu_Click(object sender, EventArgs e)
    {
      if (_isViewMenuDropDownOpened)
         {
           tsmi_ViewMenu.DropDown.Close();
           tsmi_ViewMenu.Text = "View ▲";
           _isViewMenuDropDownOpened = false;
         }
         else
         {
             tsmi_ViewMenu.Text = "View ▼";
             _isViewMenuDropDownOpened = true;
         }
    }
