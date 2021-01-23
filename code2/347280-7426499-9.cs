        private void pbItem_Click(object sender, EventArgs e)
        {
            if(MenuItemClick != null)
            {
                ToolBarCommands command;
                var res = ToolBarCommands.TryParse(((Button)sender).Name, command)
                if(res == true)                
                    MenuItemClick(this, command);
            }             
        }
       
