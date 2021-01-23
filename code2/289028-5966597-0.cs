    protected void MyMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (e.Item.Text == "Menu Item To Remove")
            {
                 MyMenu.Items.Remove(e.Item);
            }
        }
